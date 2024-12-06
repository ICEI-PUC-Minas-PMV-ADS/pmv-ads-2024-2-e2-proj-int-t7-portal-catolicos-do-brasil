using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalCatolico.Models;

namespace PortalCatolico.Controllers
{
    public class IgrejaController : Controller
    {
        private readonly AppDbContext _context;
        private static readonly HttpClient client = new HttpClient();

        public IgrejaController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Igreja.ToListAsync();

            return View(dados);
        }

        public IActionResult Create()
        {
            var viewModel = new IgrejaMissaViewModel
            {
                Igreja = new Igreja(),
                Missa = new List<Missa> { new Missa() }
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIgreja(IgrejaMissaViewModel viewModel, List<List<TimeOnly?>> horarios)
        {
            if (ModelState.IsValid)
            {
                _context.Igreja.Add(viewModel.Igreja);
                await _context.SaveChangesAsync();

                int igrejaId = viewModel.Igreja.Id;

                string[] diasSemana = { "Domingo", "Segunda-feira", "Terça-feira", "Quarta-feira", "Quinta-feira", "Sexta-feira", "Sábado" };

                for (int i = 0; i < horarios.Count; i++)
                {
                    var horariosDia = horarios[i];

                    foreach (var hora in horariosDia)
                    {
                        if (hora.HasValue)
                        {
                            string horaFormatada = hora.Value.ToString("HH:mm");

                            var missa = new Missa
                            {
                                IgrejaId = igrejaId,
                                DiaSemana = diasSemana[i],
                                Hora = horaFormatada
                            };
                            _context.Missa.Add(missa);
                            
                        }
                    }
                }

                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Igreja cadastrada com sucesso!";
                return RedirectToAction("Create", "Igreja");
            }
            return View(viewModel);
        }

        public IActionResult ResultadoPesquisa(int? igrejaId, string estado, string cidade, string bairro)
        {
            if (igrejaId.HasValue)
            {
                var igreja = _context.Igreja
                    .Include(i => i.Missas)
                    .FirstOrDefault(i => i.Id == igrejaId.Value);

                if (igreja == null)
                {
                    return NotFound();
                }

                var viewModel = new IgrejaMissaViewModel
                {
                    Igreja = igreja
                };

                return View(viewModel);
            }
            else
            {
                var igrejas = _context.Igreja
                    .Where(i => i.Estado == estado && i.Cidade == cidade && i.Bairro == bairro)
                    .Include(i => i.Missas)
                    .OrderBy(i => i.NomeIgreja)
                    .ToList();

                var viewModel = new IgrejaMissaViewModel
                {
                    Igrejas = igrejas
                };

                return View(viewModel);
            }
        }

        public IActionResult Details(int id)
        {
            var igreja = _context.Igreja.Find(id);
            if (igreja == null)
            {
                return NotFound();
            }
            return View(igreja);
        }

        [HttpGet]
        public async Task<JsonResult> GetEstados()
        {
            var estados = await _context.Igreja
                .Select(i => i.Estado)
                .Distinct()
                .ToListAsync();

            return Json(estados);
        }

        [HttpGet]
        public async Task<JsonResult> GetCidadesPorEstado(string estado)
        {
            if (!string.IsNullOrEmpty(estado))
            {
                var cidades = await _context.Igreja
                    .Where(i => i.Estado == estado)
                    .Select(i => i.Cidade)
                    .Distinct()
                    .ToListAsync();

                return Json(cidades);
            }
            return Json(new List<string>());
        }

        [HttpGet]
        public async Task<JsonResult> GetBairrosPorCidade(string cidade)
        {
            if (!string.IsNullOrEmpty(cidade))
            {
                var bairros = await _context.Igreja
                    .Where(i => i.Cidade == cidade)
                    .Select(i => i.Bairro)
                    .Distinct()
                    .ToListAsync();

                return Json(bairros);
            }
            return Json(new List<string>());
        }

        [HttpPost]
        public async Task<IActionResult> BuscarIgrejas(string estado, string cidade, string bairro)
        {
            Console.WriteLine($"Estado: {estado}, Cidade: {cidade}, Bairro: {bairro}"); // Debug

            var igrejas = await _context.Igreja
                .Where(i => (string.IsNullOrEmpty(estado) || i.Estado == estado) &&
                            (string.IsNullOrEmpty(cidade) || i.Cidade == cidade) &&
                            (string.IsNullOrEmpty(bairro) || i.Bairro == bairro))
                .Select(i => new { i.Id, i.NomeIgreja })
                .ToListAsync();

            return Json(igrejas);
        }

        [HttpPost]
        public async Task<IActionResult> BuscarIgrejaPorId(int igrejaId)
        {
            try
            {
                if (igrejaId <= 0)
                {
                    return BadRequest("ID de igreja inválido.");
                }

                var igreja = await _context.Igreja
                    .Include(i => i.Missas)
                    .FirstOrDefaultAsync(i => i.Id == igrejaId);

                if (igreja == null)
                {
                    ViewBag.Message = "Igreja não encontrada.";
                    return NotFound("Igreja não encontrada.");
                }

                var viewModel = new IgrejaMissaViewModel
                {
                    Igreja = igreja,
                    Missa = igreja.Missas.ToList()
                };

                return View("ResultadoPesquisa", viewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar a igreja: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        //[HttpPost]
        //public IActionResult BuscarPorLocalizacao([FromBody] CoordenadasViewModel coordenadas)
        //{
        //    var latitudeUsuario = coordenadas.Latitude;
        //    var longitudeUsuario = coordenadas.Longitude;

        //    // Aqui você precisa definir o raio de busca, por exemplo, 10 km
        //    double raioKm = 10.0;

        //    // Exemplo simples de busca por distância (essa lógica depende de como você armazena as coordenadas das igrejas)
        //    var igrejasProximas = _context.Igreja
        //        .Where(igreja => CalcularDistancia(latitudeUsuario, longitudeUsuario, igreja.Latitude, igreja.Longitude) <= raioKm)
        //        .ToList();

        //    return Json(igrejasProximas);
        //}

        //// Método auxiliar para calcular a distância entre duas coordenadas (em quilômetros)
        //private double CalcularDistancia(double lat1, double lon1, double lat2, double lon2)
        //{
        //    var R = 6371; // Raio da Terra em km
        //    var dLat = GrausParaRadianos(lat2 - lat1);
        //    var dLon = GrausParaRadianos(lon2 - lon1);
        //    var a =
        //        Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
        //        Math.Cos(GrausParaRadianos(lat1)) * Math.Cos(GrausParaRadianos(lat2)) *
        //        Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
        //    var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        //    var distancia = R * c;
        //    return distancia;
        //}

        //private double GrausParaRadianos(double graus)
        //{
        //    return graus * (Math.PI / 180);
        //}

    }
}

//public async Task<IActionResult> Details(int? id)
//{
//    if (id == null)
//        return NotFound();
//    var dados = await _context.Igreja.FindAsync(id);

//    if (dados == null)
//        return NotFound();

//    return View(dados);

//}


//    public async Task<IActionResult> Pesquisar(string Estado, string Cidade, string Bairro, string Igreja)
//    {
//        var query = _context.Igreja.AsQueryable();

//        if (!string.IsNullOrEmpty(Estado))
//        {
//            query = query.Where(e => e.Estado == Estado);
//        }

//        if (!string.IsNullOrEmpty(Cidade))
//        {
//            query = query.Where(e => e.Cidade == Cidade);
//        }

//        if (!string.IsNullOrEmpty(Bairro))
//        {
//            query = query.Where(e =>  e.Bairro == Bairro);
//        }

//        if (!string.IsNullOrEmpty(Igreja))
//        {
//            query = query.Where(e => e.NomeIgreja == Igreja);
//        }

//        var dadosFiltrados = await query.ToListAsync();

//        return View(dadosFiltrados);
//    }