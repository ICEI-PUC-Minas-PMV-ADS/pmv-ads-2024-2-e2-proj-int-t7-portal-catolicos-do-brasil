using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalCatolicoBrasil.Models
{
    [Table("evangelho")]
    public class Evangelho
    {
        [Key]
        [JsonProperty("id")]
        public int EvangelhoID { get; set; }

        [JsonProperty("referencia")]
        public string? Referencia { get; set; }

        [JsonProperty("titulo")]
        public string? Titulo { get; set; }

        [JsonProperty("texto")]
        public string? Texto { get; set; }
    }
}
