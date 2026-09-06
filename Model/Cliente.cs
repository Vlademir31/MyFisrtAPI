using System.ComponentModel.DataAnnotations;

namespace MyFirstAPI.Model
{
    public class Cliente
    {
        public int Id { get; set; }

       [Required]
       [MaxLength(150)]
        public string Nome { get; set; } = string.Empty;
        // = string.Empty(serve para inicializar uma propriedade com uma string vazia)
        [Required]
        [MaxLength(254)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}