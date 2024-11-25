using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PortalCatolicoBrasil.Controllers
{
    public class APIEstadoCidadeController : Controller
    {
        private readonly HttpClient _httpClient;

        public APIEstadoCidadeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Método para buscar os estados
        public async Task<IActionResult> GetEstadosAPI()
        {
            var response = await _httpClient.GetStringAsync("http://servicodados.ibge.gov.br/api/v1/localidades/estados");
            var estados = JsonConvert.DeserializeObject<List<Estado>>(response);
            Console.WriteLine(estados);
            return Json(estados);
        }

        // Modelos para os dados retornados
        public class Estado
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Sigla { get; set; }
        }

        // Método para buscar as cidades
        [HttpGet]
        public async Task<IActionResult> GetCidadesPorEstadoAPI(int estadoId)
        {
            var response = await _httpClient.GetStringAsync($"http://servicodados.ibge.gov.br/api/v1/localidades/estados/{estadoId}/municipios");
            var cidades = JsonConvert.DeserializeObject<List<Cidade>>(response);
            return Json(cidades);
        }

        // Modelos para os dados retornados
        public class Cidade
        {
            public int Id { get; set; }
            public string Nome { get; set; }
        }
    }
}