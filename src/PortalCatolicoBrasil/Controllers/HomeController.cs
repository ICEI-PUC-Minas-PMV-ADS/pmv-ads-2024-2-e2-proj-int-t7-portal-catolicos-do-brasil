using Microsoft.AspNetCore.Mvc;
using PortalCatolicoBrasil.Models;
using System.Diagnostics;

namespace PortalCatolicoBrasil.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Missas()
        {
            return View();
        }

        public IActionResult Liturgia()
        {
            return View();
        }

        public IActionResult Eventos()
        {
            return View();
        }

        public IActionResult SantoDoDia()
        {
            return View();
        }

        public IActionResult Publicacoes()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}