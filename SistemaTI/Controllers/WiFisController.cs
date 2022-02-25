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

        // Popular listas
        private void PopularLocal(object SelecaoLocal = null)
        {
            var localConsulta = from l in _context.Local
                                orderby l.Nome
                                select l;
            ViewBag.local = new SelectList(localConsulta.AsNoTracking(), "Nome", "Nome", SelecaoLocal);
        }

        private void PopularEquipamento(object SelecaoEquipamento = null)
        {
            var EquipamentoConsulta = from E in _context.ModeloFabicante
                                      
                                      orderby E.Modelo
                                      select E;
            ViewBag.Equipamento = new SelectList(EquipamentoConsulta
                .AsNoTracking()
                .Where(E => EF.Functions.Like(E.Tipo, "Roteador%"))
                , "Descricao", "Descricao", SelecaoEquipamento);
        }

        // GET: WiFis
        public async Task<IActionResult> Index()
        {

            return View(await _context.WiFi
                .OrderBy(A => A.Acesso)
                .ToListAsync());
        }

        // GET: WiFis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wiFi = await _context.WiFi
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
            PopularLocal();
            PopularEquipamento();
            return View();
        }

        // POST: WiFis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Equipamento,Acesso,UsuarioADM,SenhaADM,status,SSID,SenhaSSID,DataAlteracao,Localid")] WiFi wiFi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wiFi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            PopularEquipamento(wiFi.Equipamento);
            PopularLocal(wiFi.Localid);

            return View(wiFi);
        }

        // POST: WiFis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdWifi,Equipamento,Acesso,UsuarioADM,SenhaADM,SSID,SenhaSSID,Localid,DataAlteracao,status")] WiFi wiFi)
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
