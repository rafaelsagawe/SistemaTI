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
    public class SuprimentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuprimentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        private void PopularModelo(object SelecaoModelo = null)
        {
            var ModeloConsulta = from m in _context.ModeloFabicante
                                 orderby m.Tipo
                                 select m;
            ViewBag.Descricao = new SelectList(ModeloConsulta.AsNoTracking(), "Descricao", "Descricao", SelecaoModelo);
        }


        // GET: Suprimentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Suprimento.ToListAsync());
        }

        // GET: Suprimentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suprimento = await _context.Suprimento
                .FirstOrDefaultAsync(m => m.idSuprimento == id);
            if (suprimento == null)
            {
                return NotFound();
            }

            return View(suprimento);
        }

        // GET: Suprimentos/Create
        public IActionResult Create()
        {
            PopularModelo();
            return View();
        }

        // POST: Suprimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idSuprimento,ModeloEquipamento,TipoSuprimento,QtdSuprimento")] Suprimento suprimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suprimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(suprimento);
        }

        // GET: Suprimentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suprimento = await _context.Suprimento.FindAsync(id);
            if (suprimento == null)
            {
                return NotFound();
            }
            return View(suprimento);
        }

        // POST: Suprimentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idSuprimento,ModeloEquipamento,TipoSuprimento,QtdSuprimento")] Suprimento suprimento)
        {
            if (id != suprimento.idSuprimento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suprimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuprimentoExists(suprimento.idSuprimento))
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
            return View(suprimento);
        }

        // GET: Suprimentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suprimento = await _context.Suprimento
                .FirstOrDefaultAsync(m => m.idSuprimento == id);
            if (suprimento == null)
            {
                return NotFound();
            }

            return View(suprimento);
        }

        // POST: Suprimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suprimento = await _context.Suprimento.FindAsync(id);
            _context.Suprimento.Remove(suprimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuprimentoExists(int id)
        {
            return _context.Suprimento.Any(e => e.idSuprimento == id);
        }

        /*
            Query do controle de Estoque em SQL
SELECT  Modelo, qtdModelo, QtdSuprimento, (QtdSuprimento - qtdModelo) as Estoque from (
	SELECT Modelo, COUNT(Modelo) as qtdModelo, Suprimento.QtdSuprimento   
	from Equipamento
	inner join Suprimento on Suprimento.ModeloEquipamento=Equipamento.Modelo
	group by Modelo, QtdSuprimento) 
as Estoque;

         */
    }
}
