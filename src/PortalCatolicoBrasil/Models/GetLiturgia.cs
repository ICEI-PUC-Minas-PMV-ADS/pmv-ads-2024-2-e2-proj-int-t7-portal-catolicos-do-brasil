using Newtonsoft.Json;

namespace PortalCatolicoBrasil.Models
{
    public class GetLiturgia
    {
        public class Antifonas
        {
            [JsonProperty("entrada")]
            public string? Entrada { get; set; }

            [JsonProperty("ofertorio")]
            public string? Ofertorio { get; set; }

            [JsonProperty("comunhao")]
            public string? Comunhao { get; set; }
        }

        public class Evangelho
        {
            [JsonProperty("referencia")]
            public string? Referencia { get; set; }

            [JsonProperty("titulo")]
            public string? Titulo { get; set; }

            [JsonProperty("texto")]
            public string? Texto { get; set; }
        }

        public class PrimeiraLeitura
        {
            [JsonProperty("referencia")]
            public string? Referencia { get; set; }

            [JsonProperty("titulo")]
            public string? Titulo { get; set; }

            [JsonProperty("texto")]
            public string? Texto { get; set; }
        }

        public class Root
        {
            [JsonProperty("data")]
            public string? Data { get; set; }

            [JsonProperty("liturgia")]
            public string? Liturgia { get; set; }

            [JsonProperty("cor")]
            public string? Cor { get; set; }

            [JsonProperty("dia")]
            public string? Dia { get; set; }

            [JsonProperty("oferendas")]
            public string? Oferendas { get; set; }

            [JsonProperty("comunhao")]
            public string? Comunhao { get; set; }

            [JsonProperty("primeiraLeitura")]
            public PrimeiraLeitura? PrimeiraLeitura { get; set; }

            [JsonProperty("segundaLeitura")]
            public string? SegundaLeitura { get; set; }

            [JsonProperty("salmo")]
            public Salmo? Salmo { get; set; }

            [JsonProperty("evangelho")]
            public Evangelho? Evangelho { get; set; }

            [JsonProperty("antifonas")]
            public Antifonas? Antifonas { get; set; }
        }

        public class Salmo
        {
            [JsonProperty("referencia")]
            public string? Referencia { get; set; }

            [JsonProperty("refrao")]
            public string? Refrao { get; set; }

            [JsonProperty("texto")]
            public string? Texto { get; set; }
        }
    }

}
