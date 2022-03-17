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
    public class ItensProcessosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItensProcessosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItensProcessos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ItensProcesso.Include(i => i.Protocolo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ItensProcessos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itensProcesso = await _context.ItensProcesso
                .Include(i => i.Protocolo)
                .FirstOrDefaultAsync(m => m.ItensProcessoId == id);
            if (itensProcesso == null)
            {
                return NotFound();
            }

            return View(itensProcesso);
        }

        // GET: ItensProcessos/Create
        public IActionResult Create()
        {
            ViewData["ProcessoId"] = new SelectList(_context.Processo, "ProcessoId", "ProcessoId");
            return View();
        }

        // POST: ItensProcessos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItensProcessoId,Item,Descricao,QTD,Medida,ProcessoId,NomeSimples")] ItensProcesso itensProcesso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itensProcesso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProcessoId"] = new SelectList(_context.Processo, "ProcessoId", "ProcessoId", itensProcesso.ProcessoId);
            return View(itensProcesso);
        }

        // GET: ItensProcessos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itensProcesso = await _context.ItensProcesso.FindAsync(id);
            if (itensProcesso == null)
            {
                return NotFound();
            }
            ViewData["ProcessoId"] = new SelectList(_context.Processo, "ProcessoId", "ProcessoId", itensProcesso.ProcessoId);
            return View(itensProcesso);
        }

        // POST: ItensProcessos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItensProcessoId,Item,Descricao,QTD,Medida,ProcessoId,NomeSimples")] ItensProcesso itensProcesso)
        {
            if (id != itensProcesso.ItensProcessoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itensProcesso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItensProcessoExists(itensProcesso.ItensProcessoId))
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
            ViewData["ProcessoId"] = new SelectList(_context.Processo, "ProcessoId", "ProcessoId", itensProcesso.ProcessoId);
            return View(itensProcesso);
        }

        // GET: ItensProcessos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itensProcesso = await _context.ItensProcesso
                .Include(i => i.Protocolo)
                .FirstOrDefaultAsync(m => m.ItensProcessoId == id);
            if (itensProcesso == null)
            {
                return NotFound();
            }

            return View(itensProcesso);
        }

        // POST: ItensProcessos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itensProcesso = await _context.ItensProcesso.FindAsync(id);
            _context.ItensProcesso.Remove(itensProcesso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItensProcessoExists(int id)
        {
            return _context.ItensProcesso.Any(e => e.ItensProcessoId == id);
        }
    }
}
