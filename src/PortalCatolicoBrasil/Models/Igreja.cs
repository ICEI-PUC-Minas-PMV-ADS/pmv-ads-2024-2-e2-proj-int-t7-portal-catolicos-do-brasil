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
        [RegularExpression(@"\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}", ErrorMessage = "Formato de CNPJ inválido. O formato correto é 00.000.0000/0000-00")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Informe o Nome da igreja")]
        public string NomeIgreja { get; set; }

        [Required(ErrorMessage = "Informe o Telefone de contato da igreja")]
        [RegularExpression(@"\(\d{2}\) \d{5}-\d{4}", ErrorMessage = "Formato de telefone inválido. O formato correto é (00) 00000-0000.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe o Email")]
        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o Logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Informe o CEP")]
        [RegularExpression(@"\d{5}-\d{3}", ErrorMessage = "Formato de CEP inválido. O formato correto é 00000-000.")]
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