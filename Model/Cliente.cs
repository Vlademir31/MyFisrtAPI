namespace MyFirstAPI.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        // = string.Empty(serve para inicializar uma propriedade com uma string vazia)
        public string? Email { get; set; } = string.Empty;
    }
}