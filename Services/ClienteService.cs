using MyFirstAPI.Model;
using MyFirstAPI.Interfaces;

namespace MyFirstAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository repository;
        public ClienteService(IClienteRepository repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Cliente> ObterTodos()
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

        public bool Atualizar(Cliente cliente)
        {
            return repository.Atualizar(cliente.Id, cliente);
        }
        public bool Deletar(int id)
        {
            return repository.Remover(id);
        }
    }
}