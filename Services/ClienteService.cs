using MyFirstAPI.Model;
using MyFirstAPI.Interfaces;
using MyFirstAPI.Exceptions;

namespace MyFirstAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository repository;
        public ClienteService(IClienteRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<Cliente>> ObterTodosAsync()
        {
            return await repository.ObterTodosAsync();
        }
        public async Task<Cliente> ObterPorIdAsync(int id)
        {
            var cliente = await repository.ObterPorIdAsync(id);

            if (cliente is null)
            {
                throw new ClienteNaoEncontradoException("Cliente não encontrado.");
            }
            return cliente;
        }
        public async Task<Cliente>  AdicionarAsync(Cliente cliente)
        {
            return await repository.AdicionarAsync(cliente);
        }

        public async Task<bool> UpdateAsync(Cliente cliente)
        {
            bool atualizado = await repository.UpdateAsync(cliente.Id, cliente);

            if (!atualizado)
            {
                throw new ClienteNaoEncontradoException ("Cliente não encontrado.");
            }

            return true;
        }
        public async Task<bool> DeletarAsync(int id)
        {
            bool removido = await repository.DeletarAsync(id);

            if (!removido)
            {
                throw new ClienteNaoEncontradoException("Clente não encontrado.");
            }

            return true;
        }
    }
}