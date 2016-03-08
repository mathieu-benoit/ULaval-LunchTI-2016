using Microsoft.AspNet.Mvc;
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
