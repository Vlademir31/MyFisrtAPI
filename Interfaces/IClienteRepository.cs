using MyFirstAPI.Model;

namespace MyFirstAPI.Interfaces
{
    public interface IClienteRepository
    {
        List<Cliente> ObterTodos();

        Cliente? ObterPorId(int Id);

        Cliente Adicionar(Cliente cliente);

        bool Atualizar ( int id, Cliente cliente);

        bool Remover (int id);
        
    }
}