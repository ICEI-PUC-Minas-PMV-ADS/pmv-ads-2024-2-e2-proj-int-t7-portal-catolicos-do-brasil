using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Eventos")]
public class Evento
{
    public Evento()
    {
        ID = Guid.NewGuid().ToString(); // Gera um ID único para cada evento
    }

    [Key]
    public string ID { get; set; }

    [Required(ErrorMessage = "Informe o CNPJ")]
    public string CNPJ { get; set; }

    [Required(ErrorMessage = "Informe o Nome da paróquia")]
    public string NomeParoquia { get; set; }

    [Required(ErrorMessage = "Informe o Telefone de contato da paróquia")]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "Informe o Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Informe o Título do evento")]
    public string TituloEvento { get; set; }

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

    [Required(ErrorMessage = "Informe a Data de início")]
    public DateTime DataInicio { get; set; }

    [Required(ErrorMessage = "Informe o Horário de início")]
    public TimeSpan HorarioInicio { get; set; }

    [Required(ErrorMessage = "Informe a Data de Encerramento")]
    public DateTime DataEncerramento { get; set; }

    [Required(ErrorMessage = "Informe o Horário de encerramento")]
    public TimeSpan HorarioEncerramento { get; set; }

    [Required(ErrorMessage = "Informe o Banner")]
    public string Banner { get; set; }
}
