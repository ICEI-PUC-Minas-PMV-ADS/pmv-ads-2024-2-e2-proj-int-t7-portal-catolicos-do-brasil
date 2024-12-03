using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace PortalCatolicoBrasil.Models
{
    [Table("Eventos")]
    public class Evento
    {

        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Informe o CNPJ")]
        [RegularExpression(@"\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}", ErrorMessage = "Formato de CNPJ inválido. O formato correto é 99.999.999/0001-99")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Informe o Nome da paróquia")]
        [StringLength(100, ErrorMessage = "O nome da paróquia não pode ter mais de 100 caracteres.")]
        public string NomeParoquia { get; set; }

        [Required(ErrorMessage = "Informe o Telefone de contato da paróquia")]
        [RegularExpression(@"\(\d{2}\) \d{5}-\d{4}", ErrorMessage = "Formato de telefone inválido. O formato correto é (99) 99999-9999.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe o Email")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o Título do evento")]
        [StringLength(150, ErrorMessage = "O título do evento não pode ter mais de 150 caracteres.")]
        public string TituloEvento { get; set; }

        [Required(ErrorMessage = "Informe o Logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Informe o Número do logradouro")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Informe o CEP")]
        [RegularExpression(@"\d{5}-\d{3}", ErrorMessage = "Formato de CEP inválido. O formato correto é 99999-999.")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Informe o Estado")]
        [StringLength(2, ErrorMessage = "O estado deve ser composto por 2 caracteres (sigla).")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Informe a Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe a Data de início")]
        public DateOnly DataInicio { get; set; }

        [Required(ErrorMessage = "Informe o Horário de início")]
        public TimeSpan HorarioInicio { get; set; }

        [Required(ErrorMessage = "Informe a Data de Encerramento")]
        public DateOnly DataEncerramento { get; set; }

        [Required(ErrorMessage = "Informe o Horário de encerramento")]
        public TimeSpan HorarioEncerramento { get; set; }

        public string Banner { get; set; }

        public string BannerPath { get; set; }
    }
}
