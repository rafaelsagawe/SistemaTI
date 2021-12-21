using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaTI.Data;
using SistemaTI.Models;

namespace SistemaTI.Controllers
{
    [Authorize] // Apenas pessoas autenticadas tem acesso
    public class EquipamentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EquipamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Popular as dropdowns
        private void PopularLocal(object Selecaolocal = null)
        {
            var localConsulta = from l in _context.Local
                                orderby l.Nome
                                select l;
            ViewBag.Local = new SelectList(localConsulta.AsNoTracking(), 
                                            "Nome", // valor salvo no banco de dados
                                            "Nome", // Valor que será mostrado na dropdown
                                            Selecaolocal);
        }

        private void PopularModelo(object SelecaoModelo = null)
        {
            var ModeloConsulta = from m in _context.ModeloFabicante
                                 orderby m.Modelo
                                 select m;
            ViewBag.Modelo = new SelectList(ModeloConsulta.AsNoTracking(), "Descricao", "Descricao", SelecaoModelo);
        }


        // GET: Equipamentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Equipamento
                .OrderBy (s => s.Situacao)
                .ToListAsync());
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


        /*  Lestagem dos relatorios dos equipamentos
         *  
         *  1 - Relatorio de impressoras
         *  2 - Relatorio de distribuição 
         * 
         */

        // Quantidade de impressoras por modelo
        public async Task<ActionResult> Estatisticas()
        {
            IQueryable<Estatistica> data = from Equipamento in _context.Equipamento
                                          orderby Equipamento.Modelo
                                          group Equipamento by Equipamento.Modelo into dateGroup
                                          select new Estatistica()
                                           {
                                               EquipTipo = dateGroup.Key,
                                               ContagemImpressoras = dateGroup.Count()
                                           };
            return View(await data
                .AsNoTracking()
                .Where(m => EF.Functions.Like(m.EquipTipo, "Impressora%")) // Filtra os itens
                .ToListAsync());
        }


        // Distribuição dos equipamentos
        public async Task<ActionResult> EquipamentoLocal()
        {
            IQueryable<Estatistica> data = from Equipamento in _context.Equipamento
                                           orderby Equipamento.Local
                                           group Equipamento by Equipamento.Local into dateGroup
                                           select new Estatistica()
                                           {
                                               EquipTipo = dateGroup.Key,
                                               ContagemImpressoras = dateGroup.Count()
                                           };
            return View(await data
                .AsNoTracking()
                .ToListAsync());
        }

        // Controle de Estoque
        /* Via SQL brutas https://docs.microsoft.com/pt-br/ef/core/querying/raw-sql 
        public async Task<ActionResult> ControleEstoque()
        {
            IEnumerable<Estatistica> dados = from Modelo in Equipamento
                                             join ModeloEquipamento in _context.Suprimento
                                             on new { Modelo }
                                             equals new { ModeloEquipamento }
                                             select Modelo;


         


        }
*/
        /* Via C# https://docs.microsoft.com/pt-br/ef/core/querying/complex-query-operators
        public async Task<ActionResult> ControleEstoque()
        {
            IQueryable<Estatistica> data = from Equipamento in _context.Set<Modelo>()
                                           join Suprimento in _context.Set<ModeloEquipamento>() on Equipamento.Modelo equals Suprimento.ModeloEquipamento
                                           select new { Modelo, ModeloEquipamento };
        }

        */

        /*
        SELECT Modelo, qtdModelo, QtdSuprimento, (QtdSuprimento - qtdModelo) as Estoque from(
   SELECT Modelo, COUNT(Modelo) as qtdModelo, Suprimento.QtdSuprimento
   from Equipamento
   inner join Suprimento on Suprimento.ModeloEquipamento= Equipamento.Modelo

   group by Modelo, QtdSuprimento)
as Estoque;
        */
        private bool EquipamentoExists(int id)
        {
            return _context.Equipamento.Any(e => e.IdEquipamento == id);
        }
    }
}
