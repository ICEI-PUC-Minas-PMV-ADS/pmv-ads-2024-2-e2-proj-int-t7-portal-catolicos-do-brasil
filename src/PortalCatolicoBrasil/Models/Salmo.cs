using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalCatolicoBrasil.Models
{
    [Table("salmo")]
    public class Salmo
    {
        [Key]
        [JsonProperty("id")]
        public int SalmoID { get; set; }

        [JsonProperty("referencia")]
        public string? Referencia { get; set; }

        [JsonProperty("refrao")]
        public string? Refrao { get; set; }

        [JsonProperty("texto")]
        public string? Texto { get; set; }
    }
}
