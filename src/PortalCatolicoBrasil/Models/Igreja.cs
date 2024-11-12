using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        public List<Missa> Missas { get; set; } = new List<Missa>();
    }

    [Table("Missa")] 
    public class Missa
    {
        [Key]
        public int MissaId { get; set; }
        [ForeignKey("Igreja")]
        public int IgrejaId { get; set; }
        [JsonIgnore]
        public Igreja Igreja { get; set; }
        public string DiaSemana { get; set; }
        public string Hora { get; set; }
    }
}