using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaTI.Data;
using SistemaTI.Controllers;


namespace SistemaTI.Controllers.Dropdown
{
    public class Locais : Controller
    {

        
            private readonly ApplicationDbContext _context;

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

        
    }
}
