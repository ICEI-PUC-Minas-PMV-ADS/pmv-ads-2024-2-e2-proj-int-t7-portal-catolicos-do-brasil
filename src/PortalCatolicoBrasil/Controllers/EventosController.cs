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
            var dados = await _context.Evento.ToListAsync();
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

                _context.Evento.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction("Eventos");
            }

            return View(evento);
        }


        public async Task<IActionResult> Delete(int? ID)
        {
            if (ID == null)
                return NotFound();

            var dados = await _context.Evento.FindAsync(ID);
            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? ID)
        {
            if (ID == null)
                return NotFound();

            var dados = await _context.Evento.FindAsync(ID);
            if (dados == null)
                return NotFound();

            _context.Evento.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Eventos");
        }
        public IActionResult Search(string estado, string cidade, string bairro)
        {
            // Começamos com todos os eventos disponíveis
            IQueryable<Evento> eventos = _context.Eventos.AsQueryable();

            // Filtragem por estado
            if (!string.IsNullOrEmpty(estado))
            {
                eventos = eventos.Where(e => e.Estado.ToLower() == estado.ToLower());
            }

            // Filtragem por cidade
            if (!string.IsNullOrEmpty(cidade) && !cidade.Equals("Escolha...", StringComparison.OrdinalIgnoreCase))
            {
                eventos = eventos.Where(e => e.Cidade.ToLower() == cidade.ToLower());
            }

            // Filtragem por bairro
            if (!string.IsNullOrEmpty(bairro))
            {
                eventos = eventos.Where(e => e.Bairro.ToLower().Contains(bairro.ToLower()));
            }

            // Verificação de eventos encontrados
            if (!eventos.Any())
            {
                string mensagem = "Nenhum evento encontrado para a busca informada.";

                if (!string.IsNullOrEmpty(estado))
                {
                    mensagem += $" Estado: {estado}.";
                }

                if (!string.IsNullOrEmpty(cidade) && !cidade.Equals("Escolha...", StringComparison.OrdinalIgnoreCase))
                {
                    mensagem += $" Cidade: {cidade}.";
                }

                if (!string.IsNullOrEmpty(bairro))
                {
                    mensagem += $" Bairro: {bairro}.";
                }

                ViewBag.ErrorMessage = mensagem;
            }

            // Retorna a lista de eventos (mesmo que vazia)
            return View("Eventos", eventos.ToList());
        }
    }
}

