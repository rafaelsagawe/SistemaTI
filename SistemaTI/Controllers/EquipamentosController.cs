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
    public class EquipamentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EquipamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Popular Local de utilização
        private void PopularLocal(object Selecaolocal = null)
        {
            var localConsulta = from l in _context.Local
                                orderby l.Nome
                                select l;
            ViewBag.Local = new SelectList(localConsulta.AsNoTracking(), "Nome", "Nome", Selecaolocal);
        }

        private void PopularModelo(object SelecaoModelo = null)
        {
            var ModeloConsulta = from m in _context.ModeloFabicante
                                 orderby m.Modelo
                                 select m;
            ViewBag.Modelo = new SelectList(ModeloConsulta.AsNoTracking(), "Modelo", "Modelo", SelecaoModelo);
        }


        // GET: Equipamentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Equipamento.ToListAsync());
        }

        // GET: Equipamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamento = await _context.Equipamento
                .FirstOrDefaultAsync(m => m.IdEquipamento == id);
            if (equipamento == null)
            {
                return NotFound();
            }

            return View(equipamento);
        }

        // GET: Equipamentos/Create
        public IActionResult Create()
        {

            PopularLocal(); // Chamada do metodos para papular
            PopularModelo();
            return View();



        }

        // POST: Equipamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEquipamento,NuSerie,NuPatrimonio,EquipTipo,Modelo,EquipOrigem,EquipValor,Local,IP,Situacao")] Equipamento equipamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipamento);
        }

        // GET: Equipamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamento = await _context.Equipamento.FindAsync(id);
            if (equipamento == null)
            {
                return NotFound();
            }
            PopularLocal(equipamento.Local); // Local onde será aplica os valores obtidos
            PopularModelo(equipamento.Modelo);

            return View(equipamento);
        }

        // POST: Equipamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEquipamento,NuSerie,NuPatrimonio,EquipTipo,Modelo,EquipOrigem,EquipValor,Local,IP,Situacao")] Equipamento equipamento)
        {
            if (id != equipamento.IdEquipamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipamentoExists(equipamento.IdEquipamento))
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
            return View(equipamento);
        }

        // GET: Equipamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamento = await _context.Equipamento
                .FirstOrDefaultAsync(m => m.IdEquipamento == id);
            if (equipamento == null)
            {
                return NotFound();
            }

            return View(equipamento);
        }

        // POST: Equipamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipamento = await _context.Equipamento.FindAsync(id);
            _context.Equipamento.Remove(equipamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Função para contagem da quantidade de impressoras separadas por modelo

        public async Task<ActionResult> Estatisticas()
        {
            IQueryable<Suprimento> data = from Equipamento in _context.Equipamento
                                          orderby Equipamento.EquipTipo
                                          group Equipamento by Equipamento.EquipTipo into dateGroup
                                          select new Suprimento()
                                           {
                                               EquipTipo = dateGroup.Key,
                                               ContagemImpressoras = dateGroup.Count()
                                           };
            return View(await data
                .AsNoTracking()
              //  .Where(m => EF.Functions.Like(m.ModeloImpressora, ""))
                .ToListAsync());
        }


        private bool EquipamentoExists(int id)
        {
            return _context.Equipamento.Any(e => e.IdEquipamento == id);
        }
    }
}
