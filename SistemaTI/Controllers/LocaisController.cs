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
    public class LocaisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocaisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Locais
        public async Task<IActionResult> Index()
        {
            return View(await _context.Local.ToListAsync());
        }

        public async Task<IActionResult> IndexCasaInovacao()
        {
            return View(await _context.Local
                .Where(e => e.localTipo == "Casa da Inovação")
                .ToListAsync());
        }

        public async Task<IActionResult> IndexCasaProfessor()
        {
            return View(await _context.Local
                .Where(e => e.localTipo == "Casa do Professor")
                .ToListAsync());
        }

        public async Task<IActionResult> IndexCreche()
        {
            return View(await _context.Local
                .Where(e => e.localTipo == "Creche")
                .ToListAsync());
        }

        public async Task<IActionResult> IndexEmei()
        {
            return View(await _context.Local
                .Where(e => e.localTipo == "Escola Municipal Educação Infantil")
                .ToListAsync());
        }

        public async Task<IActionResult> IndexEscolas()
        {
            return View(await _context.Local
                .Where(e => e.localTipo == "Escola Municipal")
                .ToListAsync());
        }

        public async Task<IActionResult> IndexSetor()
        {
            return View(await _context.Local
                .Where(e => e.localTipo == "Setores da SEMED")
                .ToListAsync());
        }

        public async Task<IActionResult> IndexOutros()
        {
            return View(await _context.Local
                .Where(e => e.localTipo == "Outros")
                .ToListAsync());
        }

        // GET: Locais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var local = await _context.Local
                .Include(e => e.LocalEquipamento)
                .ThenInclude(es => es.Especificacao)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (local == null)
            {
                return NotFound();
            }

            return View(local);
        }

        // GET: Locais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,localTipo,Nome,NunProtocolo,INEP,URG,Logradouro,Numero,Bairro,CEP,Zona,Telefone,Email,Situacao,Laboratorio")] Local local)
        {
            if (ModelState.IsValid)
            {
                _context.Add(local);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(local);
        }

        // GET: Locais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var local = await _context.Local
                .Include(e => e.LocalEquipamento)
                .ThenInclude(es => es.Especificacao)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (local == null)
            {
                return NotFound();
            }
            return View(local);
        }

        // POST: Locais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,localTipo,Nome,NunProtocolo,INEP,URG,Logradouro,Numero,Bairro,CEP,Zona,Telefone,Email,Situacao,Laboratorio")] Local local)
        {
            if (id != local.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(local);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalExists(local.ID))
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
            return View(local);
        }

        // Edição da model em detalhes
        public IActionResult EditModal()
        {
            Equipamento data = new Equipamento()
            {
                //Campos com valores
                NuSerie = "3",
                Situacao = "Ativo"
            };
            TempData["mydata"] = data;
            return RedirectToAction("SaveModal", "Equipamentos");
        }

        // GET: Locais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var local = await _context.Local
                .FirstOrDefaultAsync(m => m.ID == id);
            if (local == null)
            {
                return NotFound();
            }

            return View(local);
        }

        // POST: Locais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var local = await _context.Local.FindAsync(id);
            _context.Local.Remove(local);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalExists(int id)
        {
            return _context.Local.Any(e => e.ID == id);
        }
    }
}
