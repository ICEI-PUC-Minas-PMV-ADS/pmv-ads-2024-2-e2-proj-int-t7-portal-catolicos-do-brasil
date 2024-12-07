using System.Text.Json.Serialization;

namespace PortalCatolico.Models
{
    public class EventoViewModel
    {
        [JsonIgnore]
        public Evento Evento { get; set; }
        public List<Evento> Eventos { get; set; }  // Para o caso de vários eventos
    }
}
