using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalCatolicoBrasil.Models
{
    [Table("santo_do_dia")]
    public class SantoDia
    {
        [Key]
        public DateOnly data { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
    }
}