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
    public class WiFisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WiFisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WiFis
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WiFi.Include(w => w.Especificacao).Include(w => w.Local);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WiFis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wiFi = await _context.WiFi
                .Include(w => w.Especificacao)
                .Include(w => w.Local)
                .FirstOrDefaultAsync(m => m.IdWifi == id);
            if (wiFi == null)
            {
                return NotFound();
            }

            return View(wiFi);
        }

        // GET: WiFis/Create
        public IActionResult Create()
        {
            ViewData["EspecificacaoId"] = new SelectList(_context.Especificacao, "EspecificacaoId", "Descricao");
            ViewData["LocalId"] = new SelectList(_context.Local, "ID", "Nome");
            return View();
        }

        // POST: WiFis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdWifi,EnderecoIP,UsuarioADM,SenhaADM,SSID,SenhaSSID,DataAlteracao,status,LocalId,EspecificacaoId")] WiFi wiFi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wiFi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecificacaoId"] = new SelectList(_context.Especificacao, "EspecificacaoId", "Descricao", wiFi.EspecificacaoId);
            ViewData["LocalId"] = new SelectList(_context.Local, "ID", "Nome", wiFi.LocalId);
            return View(wiFi);
        }

        // GET: WiFis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wiFi = await _context.WiFi.FindAsync(id);
            if (wiFi == null)
            {
                return NotFound();
            }
            ViewData["EspecificacaoId"] = new SelectList(_context.Especificacao, "EspecificacaoId", "Descricao", wiFi.EspecificacaoId);
            ViewData["LocalId"] = new SelectList(_context.Local, "ID", "Nome", wiFi.LocalId);
            return View(wiFi);
        }

        // POST: WiFis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdWifi,EnderecoIP,UsuarioADM,SenhaADM,SSID,SenhaSSID,DataAlteracao,status,LocalId,EspecificacaoId")] WiFi wiFi)
        {
            if (id != wiFi.IdWifi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wiFi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WiFiExists(wiFi.IdWifi))
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
            ViewData["EspecificacaoId"] = new SelectList(_context.Especificacao, "EspecificacaoId", "Descricao", wiFi.EspecificacaoId);
            ViewData["LocalId"] = new SelectList(_context.Local, "ID", "Nome", wiFi.LocalId);
            return View(wiFi);
        }

        // GET: WiFis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wiFi = await _context.WiFi
                .Include(w => w.Especificacao)
                .Include(w => w.Local)
                .FirstOrDefaultAsync(m => m.IdWifi == id);
            if (wiFi == null)
            {
                return NotFound();
            }

            return View(wiFi);
        }

        // POST: WiFis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wiFi = await _context.WiFi.FindAsync(id);
            _context.WiFi.Remove(wiFi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WiFiExists(int id)
        {
            return _context.WiFi.Any(e => e.IdWifi == id);
        }
    }
}
