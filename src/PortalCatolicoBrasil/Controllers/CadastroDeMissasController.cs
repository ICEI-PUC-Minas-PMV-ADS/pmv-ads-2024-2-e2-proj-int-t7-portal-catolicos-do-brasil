using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

using PortalCatolicoBrasil.Models;

namespace PortalCatolicoBrasil.Controllers

{

    public class MissaController : Controller

    {

        private readonly AppDbContext _context;

        public MissaController(AppDbContext context)

        {

            _context = context;

        }

        public async Task<IActionResult> Index()

        {

            var dados = await _context.Missa.ToListAsync();

            return View(dados);

        }

        public IActionResult Create()

        {

            return View();

        }

        [HttpPost]

        public async Task<IActionResult> Create(Missa missa)

        {

            if (ModelState.IsValid)

            {

                _context.Missa.Add(missa);

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Missa cadastrada com sucesso!";

                return RedirectToAction("Index", "Home");

            }

            return View(missa);

        }

    }

}

