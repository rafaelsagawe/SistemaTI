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

        // GET: Equipamentos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Equipamento
                .Include(e => e.Especificacao)
                .Include(e => e.Local)
                .Include(e => e.Processo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Equipamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamento = await _context.Equipamento
                .Include(e => e.Especificacao)
                .Include(e => e.Local)
                .Include(e => e.Processo)
                //.Include(e => e.ItemProcessoID)
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
            ViewData["EspecificacaoId"] = new SelectList(_context.Especificacao, "EspecificacaoId", "Descricao");
            ViewData["LocalId"] = new SelectList(_context.Local, "ID", "Nome") ;
            ViewData["ProcessoId"] = new SelectList(_context.Processo, "ProcessoId", "Assunto");
            ViewData["ItemProcessoID"] = new SelectList(_context.ItensProcesso, "ItensProcessoId", "NomeSimples");

            return View();
        }

        // POST: Equipamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEquipamento,NuSerie,NuPatrimonio,EquipValor,IP,Situacao,DataMovimantacao,LocalId,EspecificacaoId,ProcessoId,ItemProcessoID")] Equipamento equipamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecificacaoId"] = new SelectList(_context.Especificacao, "EspecificacaoId", "Descricao", equipamento.EspecificacaoId);
            ViewData["LocalId"] = new SelectList(_context.Local, "ID", "Nome", equipamento.LocalId);
            ViewData["ProcessoId"] = new SelectList(_context.Processo, "ProcessoId", "Assunto", equipamento.ProcessoId);
            ViewData["ItemProcessoID"] = new SelectList(_context.ItensProcesso, "ItensProcessoId", "NomeSimples", equipamento.ItemProcessoID);

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
            ViewData["EspecificacaoId"] = new SelectList(_context.Especificacao, "EspecificacaoId", "Descricao", equipamento.EspecificacaoId);
            ViewData["LocalId"] = new SelectList(_context.Local, "ID", "Nome", equipamento.LocalId);
            ViewData["ProcessoId"] = new SelectList(_context.Processo, "ProcessoId", "Assunto", equipamento.ProcessoId);
            ViewData["ItemProcessoID"] = new SelectList(_context.ItensProcesso, "ItensProcessoId", "NomeSimples", equipamento.ItemProcessoID);

            return View(equipamento);
        }

        // POST: Equipamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEquipamento,NuSerie,NuPatrimonio,EquipValor,IP,Situacao,DataMovimantacao,LocalId,EspecificacaoId,ProcessoId,ItemProcessoID")] Equipamento equipamento)
        {
            if (id != equipamento.IdEquipamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    equipamento.DataMovimantacao = DateTime.Now;
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
            ViewData["EspecificacaoId"] = new SelectList(_context.Especificacao, "EspecificacaoId", "Descricao", equipamento.EspecificacaoId);
            ViewData["LocalId"] = new SelectList(_context.Local, "ID", "Nome", equipamento.LocalId);
            ViewData["ProcessoId"] = new SelectList(_context.Processo, "ProcessoId", "Assunto", equipamento.ProcessoId);
            ViewData["ItemProcessoID"] = new SelectList(_context.ItensProcesso, "ItensProcessoId", "NomeSimples", equipamento.ItemProcessoID);

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
                .Include(e => e.Especificacao)
                .Include(e => e.Local)
                .Include(e => e.Processo)
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

        private bool EquipamentoExists(int id)
        {
            return _context.Equipamento.Any(e => e.IdEquipamento == id);
        }




        /* Ao editar e salvar o sistema deve retornar para a pagina do local */

        public async Task<IActionResult> EditVoltaLocal(int? id)
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
            ViewData["EspecificacaoId"] = new SelectList(_context.Especificacao, "EspecificacaoId", "Descricao", equipamento.EspecificacaoId);
            ViewData["LocalId"] = new SelectList(_context.Local, "ID", "Nome", equipamento.LocalId);
            ViewData["ProcessoId"] = new SelectList(_context.Processo, "ProcessoId", "Assunto", equipamento.ProcessoId);
            ViewData["ItemProcessoID"] = new SelectList(_context.ItensProcesso, "ItensProcessoId", "NomeSimples", equipamento.ItemProcessoID);

            return View(equipamento);
        }

        // POST: Equipamentos/Edit Voltando para o local/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVoltaLocal(int id, [Bind("IdEquipamento,NuSerie,NuPatrimonio,EquipValor,IP,Situacao,DataMovimantacao,LocalId,EspecificacaoId,ProcessoId,ItemProcessoID")] Equipamento equipamento)
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
                }/* Salvando o formulario será redirecionado para os detalhes do local onde o equipamento esta em uso 
                  * controller - locais
                  * Action - Details
                  * id = equipamento.LocalId
                  */
                return RedirectToRoute (new {controller = "locais", action = "Details", id = equipamento.LocalId });
            }
            ViewData["EspecificacaoId"] = new SelectList(_context.Especificacao, "EspecificacaoId", "Descricao", equipamento.EspecificacaoId);
            ViewData["LocalId"] = new SelectList(_context.Local, "ID", "Nome", equipamento.LocalId);
            ViewData["ProcessoId"] = new SelectList(_context.Processo, "ProcessoId", "Assunto", equipamento.ProcessoId);
            ViewData["ItemProcessoID"] = new SelectList(_context.ItensProcesso, "ItensProcessoId", "NomeSimples", equipamento.ItemProcessoID);

            return View(equipamento);
        }

    }
}