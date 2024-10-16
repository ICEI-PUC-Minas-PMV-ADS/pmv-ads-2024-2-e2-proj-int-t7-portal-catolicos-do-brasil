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
    }
}
