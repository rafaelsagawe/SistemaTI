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
    public class DocumentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Documentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Documentos.ToListAsync());
        }

        // GET: Documentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentos = await _context.Documentos
                .FirstOrDefaultAsync(m => m.IdDocumento == id);
            if (documentos == null)
            {
                return NotFound();
            }

            return View(documentos);
        }

        // GET: Documentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Documentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDocumento,TipoDocumento,NumeroDocumento,Destinatario,Assunto,Conteudo,DataDocumento,Status")] Documentos documentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(documentos);
        }

        // GET: Documentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentos = await _context.Documentos.FindAsync(id);
            if (documentos == null)
            {
                return NotFound();
            }
            return View(documentos);
        }

        // POST: Documentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDocumento,TipoDocumento,NumeroDocumento,Destinatario,Assunto,Conteudo,DataDocumento,Status")] Documentos documentos)
        {
            if (id != documentos.IdDocumento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentosExists(documentos.IdDocumento))
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
            return View(documentos);
        }

        // GET: Documentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentos = await _context.Documentos
                .FirstOrDefaultAsync(m => m.IdDocumento == id);
            if (documentos == null)
            {
                return NotFound();
            }

            return View(documentos);
        }

        // POST: Documentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var documentos = await _context.Documentos.FindAsync(id);
            _context.Documentos.Remove(documentos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentosExists(int id)
        {
            return _context.Documentos.Any(e => e.IdDocumento == id);
        }
    }
}
