using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PortalCatolicoBrasil.Models;
using System.Diagnostics;
using System.Net.Http;

namespace PortalCatolicoBrasil.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, AppDbContext context, HttpClient httpClient)
        {
            _logger = logger;
            _context = context;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var dataAtual = DateOnly.FromDateTime(DateTime.Now);
            var santoDoDia = await _context.SantoDia
                .Where(s => s.Data == dataAtual)
                .FirstOrDefaultAsync();

            // busca dados liturgia
            LiturgiaController.Root liturgia = null;
            try
            {
                var formattedDate = DateTime.Now.ToString("dd-MM");
                var response = await _httpClient.GetStringAsync($"https://liturgia.up.railway.app/{formattedDate}");
                liturgia = JsonConvert.DeserializeObject<LiturgiaController.Root>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar a liturgia: {ex.Message}");
                liturgia = null;
            }

            var viewModel = new HomeViewModel
            {
                SantoDoDia = santoDoDia,
                Liturgia = liturgia
            };

            return View(viewModel);
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

        public IActionResult SantoDia()
        {
            return View();
        }

        public IActionResult Publicacoes()
        {
            return View();
        }

        public IActionResult PrimeiraPublicacao()
        {
            return View();
        }

        public IActionResult SegundaPublicacao()
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