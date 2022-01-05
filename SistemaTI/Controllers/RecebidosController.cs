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
    public class RecebidosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecebidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Popular as dropdowns
        public void PopularLocal(object Selecaolocal = null)
        {
            var localConsulta = from l in _context.Local
                                orderby l.Nome
                                select l;
            ViewBag.Local = new SelectList(localConsulta.AsNoTracking(),
                                            "Nome", // valor salvo no banco de dados
                                            "Nome", // Valor que será mostrado na dropdown
                                            Selecaolocal);
        }

        public void PopularEquimentos(object SelecaoEquimentos = null)
        {
            var equipamentoConsulta = from e in _context.Equipamento
                                      orderby e.EquipTipo
                                      select e;
            ViewBag.Equipamento = new SelectList(equipamentoConsulta.AsNoTracking(), "EquipDescricao", "EquipDescricao", SelecaoEquimentos);
        }

        // GET: Recebidos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recebido.ToListAsync());
        }

        // GET: Recebidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recebido = await _context.Recebido
                .FirstOrDefaultAsync(m => m.IdDocumento == id);
            if (recebido == null)
            {
                return NotFound();
            }

            return View(recebido);
        }

        // GET: Recebidos/Create
        public IActionResult Create()
        {
            PopularLocal();
            PopularEquimentos();
            return View();
        }

        // POST: Recebidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDocumento,TipoDocumento,DataRecebimento,origem,Assunto,Status,Equipamento")] Recebido recebido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recebido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recebido);
        }

        // GET: Recebidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recebido = await _context.Recebido.FindAsync(id);
            if (recebido == null)
            {
                return NotFound();
            }
            return View(recebido);
        }

        // POST: Recebidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDocumento,TipoDocumento,DataRecebimento,origem,Assunto,Status,Equipamento")] Recebido recebido)
        {
            if (id != recebido.IdDocumento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update(recebido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecebidoExists(recebido.IdDocumento))
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
            return View(recebido);
        }

        // GET: Recebidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recebido = await _context.Recebido
                .FirstOrDefaultAsync(m => m.IdDocumento == id);
            if (recebido == null)
            {
                return NotFound();
            }

            return View(recebido);
        }

        // POST: Recebidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recebido = await _context.Recebido.FindAsync(id);
            _context.Recebido.Remove(recebido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecebidoExists(int id)
        {
            return _context.Recebido.Any(e => e.IdDocumento == id);
        }
    }
}
