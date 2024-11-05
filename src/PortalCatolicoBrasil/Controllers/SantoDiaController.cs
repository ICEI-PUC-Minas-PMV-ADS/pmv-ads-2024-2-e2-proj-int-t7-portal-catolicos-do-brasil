using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PortalCatolicoBrasil.Controllers
{
    public class SantoDiaController : Controller
    {
        private readonly AppDbContext _context;

        public SantoDiaController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var santo = await _context.SantoDia.ToListAsync();

            return View(santo);
        }

        [HttpGet]
        public async Task<IActionResult> GetSanto()
        {
            var dataAtual = DateOnly.FromDateTime(DateTime.Now);
            Console.WriteLine($"Data atual: {dataAtual}");

            var santoDoDia = await _context.SantoDia
                .Where(s => s.Data == dataAtual)  // Ajuste aqui se necessário
                .Select(s => new { s.Data, s.Nome, s.Descricao })
                .FirstOrDefaultAsync();

            if (santoDoDia == null)
            {
                return Json(new { message = "Nenhum santo encontrado para a data atual." });
            }

            return Json(santoDoDia);
        }

        [HttpGet]
        public async Task<JsonResult> GetSantoDia()
        {
            var santo = await _context.SantoDia
                .Select(s => new { s.Data, s.Nome, s.Descricao })
                .Distinct()
                .ToListAsync();

            return Json(santo);
        }


    }
}

