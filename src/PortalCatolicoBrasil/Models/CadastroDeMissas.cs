using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalCatolicoBrasil.Models
{
    [Table("CadastroDeMissas")]
    public class CadastroDeMissas
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o CNPJ")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Informe o Nome da paróquia")]
        public string NomeParoquia { get; set; }

        [Required(ErrorMessage = "Informe o Telefone de contato da paróquia")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe o Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o Logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Informe o Número do logradouro")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Informe o CEP")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Informe o Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Informe a Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o Bairro")]
        public string Bairro { get; set; }

       
    }
}
