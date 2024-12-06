using System.Text.Json.Serialization;

namespace PortalCatolico.Models
{
    public class IgrejaMissaViewModel
    {
        [JsonIgnore]
        public Igreja Igreja { get; set; }

        public List<Igreja> Igrejas { get; set; }  // Para o caso de várias igrejas

        [JsonIgnore]
        public List<Missa> Missa { get; set; } = new List<Missa>();
    }
}
