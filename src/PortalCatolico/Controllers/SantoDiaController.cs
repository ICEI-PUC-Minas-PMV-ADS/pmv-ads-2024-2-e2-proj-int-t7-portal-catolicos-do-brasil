using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static PortalCatolico.Controllers.LiturgiaController;

namespace PortalCatolico.Controllers
{
    public class SantoDiaController : Controller
    {
        private readonly AppDbContext _context;

        public SantoDiaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dataAtual = DateOnly.FromDateTime(DateTime.Now);
            var santoDoDia = await _context.SantoDia
                .Where(s => s.Data == dataAtual)
                .FirstOrDefaultAsync();

            if (santoDoDia == null)
            {
                return View("Erro", new { message = "Nenhum santo encontrado para a data atual." });
            }
            return View(santoDoDia);
        }

        [HttpGet]
        public async Task<JsonResult> GetSantoDia()
        {
            var dataAtual = DateOnly.FromDateTime(DateTime.Now);
            var santo = await _context.SantoDia
                .Where(s => s.Data == dataAtual)
                .FirstOrDefaultAsync();

            if (santo == null)
            {
                return Json("Erro", new { message = "Nenhum santo encontrado para a data atual." });
            }
            return Json(santo);
        }
    }
}