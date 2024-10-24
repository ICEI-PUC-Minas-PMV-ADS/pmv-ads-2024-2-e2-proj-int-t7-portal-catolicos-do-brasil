using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalCatolicoBrasil.Models;

namespace PortalCatolicoBrasil.Controllers
{
    public class CadastroDeMissasController : Controller
    {
        private readonly AppDbContext _context;

        public CadastroDeMissasController(AppDbContext context)
        {
            _context = context;
        } 
        
        public async Task<IActionResult> Index()
        {
            var dados = await _context.CadastroDeMissas.ToListAsync();
            
            return View(dados);
        }
    }
}
