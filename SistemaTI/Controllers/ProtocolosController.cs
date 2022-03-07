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
    public class ProtocolosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProtocolosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Protocolos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Protocolo.ToListAsync());
        }

        // GET: Protocolos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocolo = await _context.Protocolo
                .Include(t => t.Tramitar)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (protocolo == null)
            {
                return NotFound();
            }

            return View(protocolo);
        }

        // GET: Protocolos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Protocolos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Processo,Assunto,Tipo,Prazo,DataEntrada,DataRegistro,Renovacao")] Protocolo protocolo)
        {
            if (ModelState.IsValid)
            {

                protocolo.UsuarioCadastro = User.Identity.Name;
                _context.Add(protocolo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(protocolo);
        }

        // GET: Protocolos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocolo = await _context.Protocolo.FindAsync(id);
            if (protocolo == null)
            {
                return NotFound();
            }
            return View(protocolo);
        }

        // POST: Protocolos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Processo,Assunto,Tipo,Prazo,DataEntrada,DataRegistro,Renovacao")] Protocolo protocolo)
        {
            if (id != protocolo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    protocolo.DataRegistro = DateTime.Now;
                    protocolo.UsuarioCadastro = User.Identity.Name;
                    _context.Entry(protocolo).Property(de => de.DataEntrada).IsModified = false;
                    _context.Update(protocolo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProtocoloExists(protocolo.Id))
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
            return View(protocolo);
        }

        // GET: Protocolos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocolo = await _context.Protocolo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (protocolo == null)
            {
                return NotFound();
            }

            return View(protocolo);
        }

        // POST: Protocolos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var protocolo = await _context.Protocolo.FindAsync(id);
            _context.Protocolo.Remove(protocolo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProtocoloExists(int id)
        {
            return _context.Protocolo.Any(e => e.Id == id);
        }
    }
}
