using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PortalCatolicoBrasil.Models;
using System.Composition;
using ThirdParty.Json.LitJson;

namespace PortalCatolicoBrasil.Controllers
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Igreja igreja)
        {
            if (ModelState.IsValid)
            {
                _context.Igreja.Add(igreja);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Igreja cadastrada com sucesso!";
                return RedirectToAction("Index", "Home");
            }

            return View(igreja);
        }

        public IActionResult ResultadoPesquisa()
        {
            return View();
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

        public IActionResult CreateBoth()
        {
            var viewModel = new Tuple<Igreja, Missa>(new Igreja(), new Missa());
            return View(viewModel);
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
            // Filtra as igrejas com base no estado, cidade e bairro
            var igrejas = await _context.Igreja
                .Where(i => (string.IsNullOrEmpty(estado) || i.Estado == estado) &&
                            (string.IsNullOrEmpty(cidade) || i.Cidade == cidade) &&
                            (string.IsNullOrEmpty(bairro) || i.Bairro == bairro))
                .ToListAsync();

            // Retorna as igrejas como JSON
            return Json(igrejas);
        }

        [HttpPost]
        public async Task<IActionResult> BuscarIgrejaPorId(int igrejaId)
        {
            try
            {
                // Verifica se o ID foi passado corretamente
                if (igrejaId <= 0)
                {
                    return BadRequest("ID de igreja inválido.");
                }

                // Busca a igreja no banco de dados
                var igreja = await _context.Igreja.FirstOrDefaultAsync(i => i.Id == igrejaId);

                if (igreja == null)
                {
                    ViewBag.Message = "Igreja não encontrada.";
                    return View("ResultadoPesquisa", new List<Igreja>()); // Retorna uma lista vazia para manter consistência
                }

                // Retorna a igreja selecionada para a página de resultado
                return View("ResultadoPesquisa", new List<Igreja> { igreja });
            }
            catch (Exception ex)
            {
                // Loga a exceção no console para ajudar a identificar o problema
                Console.WriteLine($"Erro ao buscar a igreja: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }
    }
}

//    public async Task<IActionResult> Details(int? id)
//    {
//        if (id == null)
//            return NotFound();
//        var dados = await _context.Igreja.FindAsync(id);

//        if (dados == null)
//            return NotFound();

//        return View(dados);

//    }

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

/*
// Método para buscar os estados por API
public async Task<IActionResult> GetEstadosAPI()
{
    var response = await client.GetStringAsync("https://servicodados.ibge.gov.br/api/v1/localidades/estados");
    var estados = JsonConvert.DeserializeObject<List<Estado>>(response);
    return Json(estados);
}


// Modelos para os dados retornados pela API
public class Estado
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sigla { get; set; }
}
*/