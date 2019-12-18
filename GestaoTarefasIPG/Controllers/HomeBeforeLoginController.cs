using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GestaoTarefasIPG.Controllers
{
    public class HomeBeforeLoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contactos()
        {
            return View();
        }
        public IActionResult TermosECondicoes()
        {
            return View();
        }
    }
}