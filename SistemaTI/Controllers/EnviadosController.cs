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
    public class EnviadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnviadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enviados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Enviado.ToListAsync());
        }

        // GET: Enviados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enviado = await _context.Enviado
                .FirstOrDefaultAsync(m => m.IdEnviado == id);
            if (enviado == null)
            {
                return NotFound();
            }

            return View(enviado);
        }

        // GET: Enviados/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Enviados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEnviado,NumeroDocumento,TipoDocumento,Destino,Assunto,ResumoTexto,DataEnvio,SolitacaoStatus,DataAlteração")] Enviado enviado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enviado);
                enviado.SolitacaoStatus = "Aguardando Resposta";
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enviado);
        }

        // GET: Enviados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enviado = await _context.Enviado.FindAsync(id);
            if (enviado == null)
            {
                return NotFound();
            }
            return View(enviado);
        }

        // POST: Enviados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEnviado,NumeroDocumento,TipoDocumento,Destino,Assunto,ResumoTexto,DataEnvio,SolitacaoStatus,DataAlteração")] Enviado enviado)
        {
            if (id != enviado.IdEnviado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    enviado.DataAlteração = DateTime.Now;
                    _context.Update(enviado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnviadoExists(enviado.IdEnviado))
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
            return View(enviado);
        }

        // GET: Enviados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enviado = await _context.Enviado
                .FirstOrDefaultAsync(m => m.IdEnviado == id);
            if (enviado == null)
            {
                return NotFound();
            }

            return View(enviado);
        }

        // POST: Enviados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enviado = await _context.Enviado.FindAsync(id);
            _context.Enviado.Remove(enviado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnviadoExists(int id)
        {
            return _context.Enviado.Any(e => e.IdEnviado == id);
        }
    }
}
