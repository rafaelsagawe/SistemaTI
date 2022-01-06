using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTI.Controllers.Busca
{
    [Route("api/enviado")]
    public class EnviadoNome : Controller
    {
        //private AppContext db = new AppContext
        public IActionResult Index()
        {
            return View();
        }
    }
}
