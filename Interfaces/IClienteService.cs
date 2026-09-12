using MyFirstAPI.Model;

namespace MyFirstAPI.Interfaces
{
    public interface IClienteService
    {
       Task<IEnumerable<Cliente>> ObterTodosAsync();

        Task<Cliente> ObterPorIdAsync(int id);

        Task<Cliente> AdicionarAsync(Cliente cliente);

        Task<bool> UpdateAsync(Cliente cliente);

        Task<bool> DeletarAsync(int id);
    }
}