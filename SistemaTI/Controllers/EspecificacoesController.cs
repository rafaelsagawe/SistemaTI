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
    public class EspecificacoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EspecificacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Especificacoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Especificacao.ToListAsync());
        }

        // GET: Especificacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especificacao = await _context.Especificacao
                .FirstOrDefaultAsync(m => m.EspecificacaoId == id);
            if (especificacao == null)
            {
                return NotFound();
            }

            return View(especificacao);
        }

        // GET: Especificacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Especificacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EspecificacaoId,Tipo,Fabicante,Modelo")] Especificacao especificacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especificacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especificacao);
        }

        // GET: Especificacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especificacao = await _context.Especificacao.FindAsync(id);
            if (especificacao == null)
            {
                return NotFound();
            }
            return View(especificacao);
        }

        // POST: Especificacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EspecificacaoId,Tipo,Fabicante,Modelo")] Especificacao especificacao)
        {
            if (id != especificacao.EspecificacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especificacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecificacaoExists(especificacao.EspecificacaoId))
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
            return View(especificacao);
        }

        // GET: Especificacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especificacao = await _context.Especificacao
                .FirstOrDefaultAsync(m => m.EspecificacaoId == id);
            if (especificacao == null)
            {
                return NotFound();
            }

            return View(especificacao);
        }

        // POST: Especificacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var especificacao = await _context.Especificacao.FindAsync(id);
            _context.Especificacao.Remove(especificacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecificacaoExists(int id)
        {
            return _context.Especificacao.Any(e => e.EspecificacaoId == id);
        }
    }
}
