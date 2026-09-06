using MyFirstAPI.Model;

namespace MyFirstAPI.Interfaces
{
    public interface IClienteService
    {
       IEnumerable<Cliente> ObterTodos();

        Cliente? ObterPorId(int id);

        Cliente Adicionar(Cliente cliente);

        bool Update(Cliente cliente);

        bool Deletar(int id);
    }
}