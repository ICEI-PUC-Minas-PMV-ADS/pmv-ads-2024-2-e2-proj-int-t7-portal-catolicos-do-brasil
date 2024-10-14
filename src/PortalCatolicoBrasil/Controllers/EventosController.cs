using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalCatolicoBrasil.Models;


namespace PortalCatolicoBrasil.Controllers
{
    public class EventoController : Controller
    {
        private readonly IWebHostEnvironment _webhost;
        private readonly AppDbContext _context;

        public EventoController(IWebHostEnvironment webHost, AppDbContext context)
        {
            _webhost = webHost;
            _context = context;
        }

        public async Task<IActionResult> Eventos()
        {
            var dados = await _context.Eventos.ToListAsync();
            return View(dados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Evento evento, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string uploadsfolder = Path.Combine(_webhost.WebRootPath, "uploads");
                if (!Directory.Exists(uploadsfolder))
                {
                    Directory.CreateDirectory(uploadsfolder);
                }

                string fileName = Path.GetFileName(file.FileName);
                string filesavepath = Path.Combine(uploadsfolder, fileName);
                using (FileStream stream = new FileStream(filesavepath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Store the file path or name in the Evento model if necessary
                evento.BannerPath = fileName;

                _context.Eventos.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction("Eventos");
            }

            return View(evento);
        }

        public async Task<IActionResult> Delete(int? ID)
        {
            if (ID == null)
                return NotFound();

            var dados = await _context.Eventos.FindAsync(ID);
            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? ID)
        {
            if (ID == null)
                return NotFound();

            var dados = await _context.Eventos.FindAsync(ID);
            if (dados == null)
                return NotFound();

            _context.Eventos.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Eventos");
        }
    }
}
