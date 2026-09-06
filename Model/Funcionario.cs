using System.ComponentModel.DataAnnotations;

namespace MyFirstAPI.Model
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [MaxLength(14)]
        public string Cpf { get; set; } = string.Empty;
        
        [MaxLength(254)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Telefone { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Cargo { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Departamento { get; set; } = string.Empty;
         public DateTime DataAdmissao { get; set; } 
        public bool Ativo { get; set; } = true;


    }
}