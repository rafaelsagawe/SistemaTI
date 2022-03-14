using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaTI.Data;
using SistemaTI.Models;

namespace SistemaTI.Controllers
{
    public class SuprimentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuprimentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Suprimentos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Suprimento.Include(s => s.Especificacao);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Suprimentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suprimento = await _context.Suprimento
                .Include(s => s.Especificacao)
                .FirstOrDefaultAsync(m => m.idSuprimento == id);
            if (suprimento == null)
            {
                return NotFound();
            }

            return View(suprimento);
        }

        // GET: Suprimentos/Create
        public IActionResult Create()
        {
            ViewData["EspecificacaoId"] = new SelectList(_context.Especificacao, "EspecificacaoId", "Fabicante");
            return View();
        }

        // POST: Suprimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idSuprimento,EspecificacaoId,TipoSuprimento,QtdSuprimento")] Suprimento suprimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suprimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecificacaoId"] = new SelectList(_context.Especificacao, "EspecificacaoId", "Fabicante", suprimento.EspecificacaoId);
            return View(suprimento);
        }

        // GET: Suprimentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suprimento = await _context.Suprimento.FindAsync(id);
            if (suprimento == null)
            {
                return NotFound();
            }
            ViewData["EspecificacaoId"] = new SelectList(_context.Especificacao, "EspecificacaoId", "Fabicante", suprimento.EspecificacaoId);
            return View(suprimento);
        }

        // POST: Suprimentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idSuprimento,EspecificacaoId,TipoSuprimento,QtdSuprimento")] Suprimento suprimento)
        {
            if (id != suprimento.idSuprimento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suprimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuprimentoExists(suprimento.idSuprimento))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecificacaoId"] = new SelectList(_context.Especificacao, "EspecificacaoId", "Fabicante", suprimento.EspecificacaoId);
            return View(suprimento);
        }

        // GET: Suprimentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suprimento = await _context.Suprimento
                .Include(s => s.Especificacao)
                .FirstOrDefaultAsync(m => m.idSuprimento == id);
            if (suprimento == null)
            {
                return NotFound();
            }

            return View(suprimento);
        }

        // POST: Suprimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suprimento = await _context.Suprimento.FindAsync(id);
            _context.Suprimento.Remove(suprimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuprimentoExists(int id)
        {
            return _context.Suprimento.Any(e => e.idSuprimento == id);
        }
    }
}
