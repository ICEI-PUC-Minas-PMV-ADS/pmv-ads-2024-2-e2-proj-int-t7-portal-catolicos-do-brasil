using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalCatolicoBrasil.Models
{
    [Table("Missa")]
    public class Missa
    {
        [Key]
        public int missa_id { get; set; }

        [ForeignKey("Id")]
        public Igreja igreja_id { get; set; }

        public string dia_semana { get; set; }

        public TimeOnly? hora1 { get; set; }

        public TimeOnly? hora2 { get; set; }
        public TimeOnly? hora3 { get; set; }
        public TimeOnly? hora4 { get; set; }
        public TimeOnly? hora5 { get; set; }
        public TimeOnly? hora6 { get; set; }
    }
}