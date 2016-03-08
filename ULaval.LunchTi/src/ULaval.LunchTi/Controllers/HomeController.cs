using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ULaval.LunchTi.Models;

namespace ULaval.LunchTi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new HomeModel() { Title = "Hello, World !" });
        }
    }
}
