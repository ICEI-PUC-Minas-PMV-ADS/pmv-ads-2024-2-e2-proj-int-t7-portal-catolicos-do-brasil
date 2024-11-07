using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalCatolicoBrasil.Models
{
    [Table("Igreja")]
    public class Igreja
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o CNPJ")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Informe o Nome da igreja")]
        public string NomeIgreja { get; set; }

        [Required(ErrorMessage = "Informe o Telefone de contato da igreja")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe o Email")]
        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o Logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Informe o CEP")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Informe o Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Informe a Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o Bairro")]
        public string Bairro { get; set; }

        public ICollection<DiaMissa> DiaMissa { get; set; }
    }

    [Table("DiaMissa")]
    public class DiaMissa
    {
        [Key]
        public int DiaMissaId { get; set; }

        [ForeignKey("Igreja")]
        public int IgrejaId { get; set; }
        public Igreja Igreja { get; set; }

        public string DiaSemana { get; set; }

        public ICollection<HoraMissa> HoraMissa { get; set; }
    }

    [Table("HoraMissa")]
    public class HoraMissa
    {
        [Key]
        public int HoraMissaId { get; set; }

        [ForeignKey("DiaMissa")]
        public int DiaMissaId { get; set; }
        public DiaMissa DiaMissa { get; set; }

        public TimeOnly? Hora1 { get; set; }
        public TimeOnly? Hora2 { get; set; }
        public TimeOnly? Hora3 { get; set; }
        public TimeOnly? Hora4 { get; set; }
        public TimeOnly? Hora5 { get; set; }
        public TimeOnly? Hora6 { get; set; }
    }

    public class IgrejaMissaViewModel
    {
        public Igreja Igreja { get; set; }
        public DiaMissa DiaMissa { get; set; }
        public HoraMissa HoraMissa { get; set; }
    }



    //[Table("Missa")]                   NOVA TABELA DE SUBSTITUIÇÃO
    //public class Missa
    //{
    //    [Key]
    //    public int MissaId { get; set; }

    //    [ForeignKey("Igreja")]
    //    public int IgrejaId { get; set; }
    //    public Igreja Igreja { get; set; }

    //    public string DiaSemana { get; set; }
    //    public TimeOnly? Hora { get; set; }
    //}
}