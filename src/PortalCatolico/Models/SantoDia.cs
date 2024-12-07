using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalCatolico.Models
{
    [Table("SantoDia")]
    public class SantoDia
    {
        [Key]
        public DateOnly Data { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}