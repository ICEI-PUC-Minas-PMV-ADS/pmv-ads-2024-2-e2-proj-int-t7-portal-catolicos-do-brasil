using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalCatolico.Models;

namespace PortalCatolico.Controllers
{
    public class EventoController : Controller
    {
        private readonly AppDbContext _context;

        public EventoController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            var viewModel = new EventoViewModel
            {
                Evento = new Evento()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Evento.Add(viewModel.Evento);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = $"{viewModel.Evento.TituloEvento} cadastrado com sucesso!";
                return RedirectToAction("Create", "Evento");
            }
            return View(viewModel);
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

        public IActionResult Index(int? eventoId, string estado, string cidade, string bairro)
        {
            if (eventoId.HasValue)
            {
                var evento = _context.Evento
                    .FirstOrDefault(i => i.ID == eventoId.Value);

                if (evento == null)
                {
                    return NotFound();
                }

                var viewModel = new EventoViewModel
                {
                    Evento = evento
                };

                return View(viewModel);
            }
            else
            {
                var eventos = _context.Evento
                    .Where(i => i.Estado == estado && i.Cidade == cidade && i.Bairro == bairro)
                    .OrderBy(i => i.TituloEvento)
                    .ToList();

                var viewModel = new EventoViewModel
                {
                    Eventos = eventos
                };

                return View(viewModel);
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetEstadosEventos()
        {
            var estados = await _context.Evento
                .Select(i => i.Estado)
                .Distinct()
                .ToListAsync();

            return Json(estados);
        }

        [HttpGet]
        public async Task<JsonResult> GetCidadesPorEstadoEventos(string estado)
        {
            if (!string.IsNullOrEmpty(estado))
            {
                var cidades = await _context.Evento
                    .Where(i => i.Estado == estado)
                    .Select(i => i.Cidade)
                    .Distinct()
                    .ToListAsync();

                return Json(cidades);
            }
            return Json(new List<string>());
        }

        [HttpGet]
        public async Task<JsonResult> GetBairrosPorCidadeEventos(string cidade)
        {
            if (!string.IsNullOrEmpty(cidade))
            {
                var bairros = await _context.Evento
                    .Where(i => i.Cidade == cidade)
                    .Select(i => i.Bairro)
                    .Distinct()
                    .ToListAsync();

                return Json(bairros);
            }
            return Json(new List<string>());
        }

        [HttpPost]
        public async Task<IActionResult> BuscarEventos(string estado, string cidade, string bairro)
        {
            Console.WriteLine($"Estado: {estado}, Cidade: {cidade}, Bairro: {bairro}"); // Debug

            var eventos = await _context.Evento
                .Where(i => (string.IsNullOrEmpty(estado) || i.Estado == estado) &&
                            (string.IsNullOrEmpty(cidade) || i.Cidade == cidade) &&
                            (string.IsNullOrEmpty(bairro) || i.Bairro == bairro))
                .Select(i => new { i.ID, i.TituloEvento })
                .ToListAsync();

            return Json(eventos);
        }

        [HttpPost]
        public async Task<IActionResult> BuscarEventoPorId(int eventoId)
        {
            try
            {
                if (eventoId <= 0)
                {
                    return BadRequest("ID do evento inválido.");
                }

                var evento = await _context.Evento
                    .FirstOrDefaultAsync(i => i.ID == eventoId);

                if (evento == null)
                {
                    ViewBag.Message = "Evento não encontrado.";
                    return NotFound("Evento não encontrado.");
                }

                var viewModel = new EventoViewModel
                {
                    Evento = evento
                };

                return View("Index", viewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar o evento: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }
    }
}