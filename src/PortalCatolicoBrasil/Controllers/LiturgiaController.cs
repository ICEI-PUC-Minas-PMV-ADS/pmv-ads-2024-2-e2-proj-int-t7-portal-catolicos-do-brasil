using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.MSIdentity.Shared;
using Newtonsoft.Json;
using static PortalCatolicoBrasil.Controllers.LiturgiaController;

namespace PortalCatolicoBrasil.Controllers
{
    public class LiturgiaController : Controller
    {
        private readonly HttpClient _httpClient;

        public LiturgiaController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Método para buscar os estados
        public async Task<IActionResult> GetLiturgiaAPI(DateTime date)
        {
            var formattedDate = DateTime.Now.ToString("dd-MM");
            var response = await _httpClient.GetStringAsync($"https://liturgia.up.railway.app/{formattedDate}");
            var liturgia = JsonConvert.DeserializeObject<Root>(response);
            Console.WriteLine(liturgia);
            return Json(liturgia);
        }

        public class Antifonas
        {
            public string Entrada { get; set; }
            public string Ofertorio { get; set; }
            public string Comunhao { get; set; }
        }

        public class Evangelho
        {
            public string Referencia { get; set; }
            public string Titulo { get; set; }
            public string Texto { get; set; }
        }

        public class PrimeiraLeitura
        {
            public string Referencia { get; set; }
            public string Titulo { get; set; }
            public string Texto { get; set; }
        }

        public class Root
        {
            public string Data { get; set; }
            public string Liturgia { get; set; }
            public string Cor { get; set; }
            public string Dia { get; set; }
            public string Oferendas { get; set; }
            public string Comunhao { get; set; }
            public PrimeiraLeitura PrimeiraLeitura { get; set; }
            public string SegundaLeitura { get; set; }
            public Salmo Salmo { get; set; }
            public Evangelho Evangelho { get; set; }
            public Antifonas Antifonas { get; set; }
        }

        public class Salmo
        {
            public string Referencia { get; set; }
            public string Refrao { get; set; }
            public string Texto { get; set; }
        }




        // Modelos para os dados retornados
        //public class Liturgia
        //{
        //    public Root Root { get; set; }
        //    public Evangelho Evangelho { get; set; }
        //    public Antifonas Antifonas { get; set; }
        //    public PrimeiraLeitura PrimeiraLeitura { get; set; }
        //    public Salmo Salmo { get; set;}
        //}
    }
}
