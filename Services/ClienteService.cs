using MyFirstAPI.Model;
using MyFirstAPI.Repository;

namespace MyFirstAPI.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository repository = new ClienteRepository();
        public List<Cliente> ObterTodos()
        {
            return repository.ObterTodos();
        }
        public Cliente? ObterPorId(int id)
        {
            return repository.ObterPorId(id);
        }
        public Cliente Adicionar(Cliente cliente)
        {
            return repository.Adicionar(cliente);
        }

        public bool Atualizar(int id, Cliente cliente)
        {
            return repository.Atualizar(id, cliente);
        }
        public bool Deletar(int id)
        {
            return repository.Remover(id);
        }
    }
}