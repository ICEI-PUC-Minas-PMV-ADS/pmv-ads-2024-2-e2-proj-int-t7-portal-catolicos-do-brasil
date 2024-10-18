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

        //public async Task<IActionResult> Index()
        //{
        //    var dados = await _context.Liturgia.ToListAsync();
        //    return View(dados);
        //}
    }
}