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
    public class TramitacoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TramitacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tramitacoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tramitacao.Include(t => t.Protocolo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tramitacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tramitacao = await _context.Tramitacao
                .Include(t => t.Protocolo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tramitacao == null)
            {
                return NotFound();
            }

            return View(tramitacao);
        }

        // GET: Tramitacoes/Create
        public IActionResult Create()
        {
            ViewData["ProcessoId"] = new SelectList(_context.Processo, "ProcessoId", "ProcessoId");
            return View();
        }

        // POST: Tramitacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Movimentacao,Localizacao,UsuarioTramitacao,ProcessoId")] Tramitacao tramitacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tramitacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProcessoId"] = new SelectList(_context.Processo, "ProcessoId", "ProcessoId", tramitacao.ProcessoId);
            return View(tramitacao);
        }

        // GET: Tramitacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tramitacao = await _context.Tramitacao.FindAsync(id);
            if (tramitacao == null)
            {
                return NotFound();
            }
            ViewData["ProcessoId"] = new SelectList(_context.Processo, "ProcessoId", "ProcessoId", tramitacao.ProcessoId);
            return View(tramitacao);
        }

        // POST: Tramitacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Movimentacao,Localizacao,UsuarioTramitacao,ProcessoId")] Tramitacao tramitacao)
        {
            if (id != tramitacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tramitacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TramitacaoExists(tramitacao.Id))
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
            ViewData["ProcessoId"] = new SelectList(_context.Processo, "ProcessoId", "ProcessoId", tramitacao.ProcessoId);
            return View(tramitacao);
        }

        // GET: Tramitacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tramitacao = await _context.Tramitacao
                .Include(t => t.Protocolo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tramitacao == null)
            {
                return NotFound();
            }

            return View(tramitacao);
        }

        // POST: Tramitacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tramitacao = await _context.Tramitacao.FindAsync(id);
            _context.Tramitacao.Remove(tramitacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TramitacaoExists(int id)
        {
            return _context.Tramitacao.Any(e => e.Id == id);
        }
    }
}
