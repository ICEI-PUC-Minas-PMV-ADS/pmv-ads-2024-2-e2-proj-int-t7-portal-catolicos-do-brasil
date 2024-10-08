using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalCatolicoBrasil.Models
{
    [Table("primeira_leitura")]
    public class PrimeiraLeitura
    {
        [Key]
        [JsonProperty("id")]
        public int PrimeiraLeituraID { get; set; }

        [JsonProperty("referencia")]
        public string? Referencia { get; set; }

        [JsonProperty("titulo")]
        public string? Titulo { get; set; }

        [JsonProperty("texto")]
        public string? Texto { get; set; }
    }
}
