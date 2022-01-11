using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTI.Controllers
{
    public class GerenteController : Controller
    {
        // Controler do Gerente do Sistema para a função de Regras
        [Authorize(Roles ="Gerente")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
