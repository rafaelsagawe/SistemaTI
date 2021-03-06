using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaTI.Data;
using SistemaTI.Models;
// 1º Para a criação da contagem de itens entregues do contrato
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace SistemaTI.Controllers
{
    public class ProcessosController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        
        public ProcessosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Processos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Processo.ToListAsync());
        }

        // GET: Processos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processo = await _context.Processo
                .Include(i => i.ItensProcesso)
                /*Instrução em SQL
        -- Contagem de equipamentos com base no processo
	        SELECT  Assunto, NomeSimples,COUNT(NomeSimples) 
	        from SistemaTIv2.dbo.Equipamento
	        inner join  SistemaTIv2.dbo.ItensProcesso on  (Equipamento.ItemProcessoID = ItensProcesso.ItensProcessoId)
	        inner join  SistemaTIv2.dbo.Processo on  (Equipamento.ProcessoId  = SistemaTIv2.dbo.Processo.ProcessoId)
	        GROUP by NomeSimples, Assunto;
                */
                .FirstOrDefaultAsync(m => m.ProcessoId == id);
            if (processo == null)
            {
                return NotFound();
            }

            return View(processo);
        }

        // GET: Processos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Processos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProcessoId,NumeroProcesso,Assunto,Tipo,Prazo,DataEntrada,DataRegistro,DataEncerramento,Renovacao,UsuarioCadastro")] Processo processo)
        {
            if (ModelState.IsValid)
            {
                processo.UsuarioCadastro = User.Identity.Name;
                processo.DataEncerramento = DateTime.Now.AddMonths(processo.Prazo);
                processo.DataRegistro = DateTime.Now;
                _context.Add(processo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(processo);
        }

        // GET: Processos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processo = await _context.Processo.FindAsync(id);
            if (processo == null)
            {
                return NotFound();
            }
            return View(processo);
        }

        // POST: Processos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProcessoId,NumeroProcesso,Assunto,Tipo,Prazo,DataEntrada,DataEncerramento,DataRegistro,Renovacao,UsuarioCadastro")] Processo processo)
        {
            if (id != processo.ProcessoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    processo.DataRegistro = DateTime.Now;
                    processo.UsuarioCadastro = User.Identity.Name;
                    processo.DataEncerramento = DateTime.Now.AddMonths(processo.Prazo);
                    _context.Update(processo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessoExists(processo.ProcessoId))
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
            return View(processo);
        }

        // GET: Processos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processo = await _context.Processo
                .FirstOrDefaultAsync(m => m.ProcessoId == id);
            if (processo == null)
            {
                return NotFound();
            }

            return View(processo);
        }

        // POST: Processos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var processo = await _context.Processo.FindAsync(id);
            _context.Processo.Remove(processo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessoExists(int id)
        {
            return _context.Processo.Any(e => e.ProcessoId == id);
        }

        public async Task<ActionResult> ItensEntregues()
        {
            IQueryable<GrupoItensEntregues> data =
                from Equipamento in _context.Equipamento
                group Equipamento by Equipamento.ItemProcessoID into dataGroup
                select new GrupoItensEntregues()
                {
                    ItemEntegue = dataGroup.Key,
                    SomaItemEntregue = dataGroup.Count()
                };
            return View(await data
                        .AsNoTracking()
                        .ToListAsync());
        }
    }
}
