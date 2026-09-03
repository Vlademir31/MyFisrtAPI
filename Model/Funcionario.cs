using System.ComponentModel.DataAnnotations;

namespace MyFirstAPI.Model
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
         public DateTime DataAdmissao { get; set; } 
        public bool Ativo { get; set; } = true;


    }
}