using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static PortalCatolicoBrasil.Controllers.LiturgiaController;

namespace PortalCatolicoBrasil.Controllers
{
    public class SantoDiaController : Controller
    {
        private readonly AppDbContext _context;

        public SantoDiaController(AppDbContext context)
        {
            _context = context;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var santo = await _context.SantoDia.ToListAsync();

        //    return View(santo);
        //}

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dataAtual = DateOnly.FromDateTime(DateTime.Now);
            var santoDoDia = await _context.SantoDia
                .Where(s => s.Data == dataAtual)  // Ajuste aqui se necessário
                .FirstOrDefaultAsync();

            if (santoDoDia == null)
            {
                return View("Erro", new { message = "Nenhum santo encontrado para a data atual." });
            }
            return View(santoDoDia);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetSanto()
        //{
        //    var dataAtual = DateOnly.FromDateTime(DateTime.Now);
        //    Console.WriteLine($"Data atual: {dataAtual}");

        //    var santoDoDia = await _context.SantoDia
        //        .Where(s => s.Data == dataAtual)  // Ajuste aqui se necessário
        //        .Select(s => new { s.Data, s.Nome, s.Descricao })
        //        .FirstOrDefaultAsync();

        //    if (santoDoDia == null)
        //    {
        //        return Json(new { message = "Nenhum santo encontrado para a data atual." });
        //    }

        //    return Json(santoDoDia);
        //}

        [HttpGet]
        public async Task<JsonResult> GetSantoDia()
        {
            var dataAtual = DateOnly.FromDateTime(DateTime.Now);
            var santo = await _context.SantoDia
                .Where(s => s.Data == dataAtual)  // Ajuste aqui se necessário
                .FirstOrDefaultAsync();

            if (santo == null)
            {
                return Json("Erro", new { message = "Nenhum santo encontrado para a data atual." });
            }
            return Json(santo);
        }


    }
}