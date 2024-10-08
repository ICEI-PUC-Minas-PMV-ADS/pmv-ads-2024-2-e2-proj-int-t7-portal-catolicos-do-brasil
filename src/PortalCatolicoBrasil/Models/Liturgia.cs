using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using PortalCatolicoBrasil.Models;
using System.ComponentModel.DataAnnotations;

namespace PortalCatolicoBrasil.Models
{
    public class Liturgia
    {
        [Key]
        [JsonProperty("id")]
        public int LiturgiaID { get; set; }

        [JsonProperty("data")]
        public string? Data { get; set; }

        [JsonProperty("liturgia_text")]
        public string? LiturgiaText { get; set; }

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
        public Antifona? Antifonas { get; set; }

        ForeignKeyAttribute? SalmoID { get; set; }
        ForeignKeyAttribute? EvangelhoID { get; set; }
        ForeignKeyAttribute? PrimeiraLeituraID { get; set; }
        ForeignKeyAttribute? SegundaLeituraID { get; set; }
        ForeignKeyAttribute? AntifonaID { get; set; }
    }
}
