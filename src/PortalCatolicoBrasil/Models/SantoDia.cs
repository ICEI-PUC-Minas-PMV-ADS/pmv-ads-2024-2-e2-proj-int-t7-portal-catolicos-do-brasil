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

    [Table("paroquia")]
    public class Paroquia
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
    }

    [Table("missa")]
    public class Missa
    {
        [Key]
        public int igreja_id { get; set; }
        public string dia_semana { get; set; }
        public DateTime hora_1 { get; set; }
        public DateTime hora_2 { get; set; }
        public DateTime hora_3 { get; set; }
        public DateTime hora_4 { get; set; }
        public DateTime hora_5 { get; set; }
        public DateTime hora_6 { get; set; }
    }
}
