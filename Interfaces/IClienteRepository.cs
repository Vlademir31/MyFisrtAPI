using MyFirstAPI.Model;

namespace MyFirstAPI.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> ObterTodosAsync();

       Task<Cliente?>  ObterPorIdAsync(int Id);

        Task<Cliente> AdicionarAsync(Cliente cliente);

        Task<bool> UpdateAsync (int id, Cliente cliente);

        Task<bool> DeletarAsync (int id);
        
    }
}