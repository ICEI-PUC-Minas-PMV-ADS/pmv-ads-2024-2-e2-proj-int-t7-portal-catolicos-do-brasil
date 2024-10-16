using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace PortalCatolicoBrasil.Controllers
{
    public class APILiturgiaController : Controller
    {
        private readonly AppDbContext _context;

        public APILiturgiaController(AppDbContext context)
        {
            _context = context;
        }

        // Método para retorna os dados salvos no banco com referencia a liturgia
        public async Task<IActionResult> Index()
        {
            var dados = await _context.Liturgias.ToListAsync();
            return View(dados);
        }
    }
}