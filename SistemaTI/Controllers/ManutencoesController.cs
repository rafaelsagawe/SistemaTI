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
    public class ManutencoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManutencoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Manutencoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Manutencao.Include(m => m.Equipamento).Include(m => m.Local);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Manutencoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manutencao = await _context.Manutencao
                .Include(m => m.Equipamento)
                .Include(m => m.Local)
                .FirstOrDefaultAsync(m => m.ManutencaoID == id);
            if (manutencao == null)
            {
                return NotFound();
            }

            return View(manutencao);
        }

        // GET: Manutencoes/Create
        public IActionResult Create()
        {
            ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "IdEquipamento", "IdEquipamento");
            ViewData["LocalId"] = new SelectList(_context.Local, "ID", "ID");
            return View();
        }

        // POST: Manutencoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ManutencaoID,Motivo,DataSolicitacao,EquipamentoId,LocalId")] Manutencao manutencao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manutencao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "IdEquipamento", "IdEquipamento", manutencao.EquipamentoId);
            ViewData["LocalId"] = new SelectList(_context.Local, "ID", "ID", manutencao.LocalId);
            return View(manutencao);
        }

        // GET: Manutencoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manutencao = await _context.Manutencao.FindAsync(id);
            if (manutencao == null)
            {
                return NotFound();
            }
            ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "IdEquipamento", "IdEquipamento", manutencao.EquipamentoId);
            ViewData["LocalId"] = new SelectList(_context.Local, "ID", "ID", manutencao.LocalId);
            return View(manutencao);
        }

        // POST: Manutencoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ManutencaoID,Motivo,DataSolicitacao,EquipamentoId,LocalId")] Manutencao manutencao)
        {
            if (id != manutencao.ManutencaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manutencao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManutencaoExists(manutencao.ManutencaoID))
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
            ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "IdEquipamento", "IdEquipamento", manutencao.EquipamentoId);
            ViewData["LocalId"] = new SelectList(_context.Local, "ID", "ID", manutencao.LocalId);
            return View(manutencao);
        }

        // GET: Manutencoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manutencao = await _context.Manutencao
                .Include(m => m.Equipamento)
                .Include(m => m.Local)
                .FirstOrDefaultAsync(m => m.ManutencaoID == id);
            if (manutencao == null)
            {
                return NotFound();
            }

            return View(manutencao);
        }

        // POST: Manutencoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manutencao = await _context.Manutencao.FindAsync(id);
            _context.Manutencao.Remove(manutencao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManutencaoExists(int id)
        {
            return _context.Manutencao.Any(e => e.ManutencaoID == id);
        }
    }
}
