using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalCatolicoBrasil.Models
{

    [Table("antifona")]
    public class Antifona
    {
        [Key]
        [JsonProperty("id")]
        public int AntifonaID { get; set; }

        [JsonProperty("entrada")]
        public string? Entrada { get; set; }

        [JsonProperty("ofertorio")]
        public string? Ofertorio { get; set; }

        [JsonProperty("comunhao")]
        public string? Comunhao { get; set; }

    }

}
