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
    public class ModelosFabicantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModelosFabicantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ModelosFabicantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ModeloFabicante.ToListAsync());
        }

        // GET: ModelosFabicantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloFabicante = await _context.ModeloFabicante
                .FirstOrDefaultAsync(m => m.idModelo == id);
            if (modeloFabicante == null)
            {
                return NotFound();
            }

            return View(modeloFabicante);
        }

        // GET: ModelosFabicantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModelosFabicantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idModelo,Fabicante,Modelo")] ModeloFabicante modeloFabicante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modeloFabicante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modeloFabicante);
        }

        // GET: ModelosFabicantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloFabicante = await _context.ModeloFabicante.FindAsync(id);
            if (modeloFabicante == null)
            {
                return NotFound();
            }
            return View(modeloFabicante);
        }

        // POST: ModelosFabicantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idModelo,Fabicante,Modelo")] ModeloFabicante modeloFabicante)
        {
            if (id != modeloFabicante.idModelo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modeloFabicante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloFabicanteExists(modeloFabicante.idModelo))
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
            return View(modeloFabicante);
        }

        // GET: ModelosFabicantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloFabicante = await _context.ModeloFabicante
                .FirstOrDefaultAsync(m => m.idModelo == id);
            if (modeloFabicante == null)
            {
                return NotFound();
            }

            return View(modeloFabicante);
        }

        // POST: ModelosFabicantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modeloFabicante = await _context.ModeloFabicante.FindAsync(id);
            _context.ModeloFabicante.Remove(modeloFabicante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloFabicanteExists(int id)
        {
            return _context.ModeloFabicante.Any(e => e.idModelo == id);
        }
    }
}
