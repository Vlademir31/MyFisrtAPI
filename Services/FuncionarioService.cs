
using MyFirstAPI.Interfaces;
using MyFirstAPI.Model;
using MyFirstAPI.Exceptions;

namespace MyFirstAPI.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository repository;

        public FuncionarioService(IFuncionarioRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Funcionario>> ObterTodosAsync()
        {
            return await repository.ObterTodosAsync();
        }

        public async Task<Funcionario> ObterPorIdAsync(int id)
        {
            var funcionario = await  repository.ObterPorIdAsync(id);

            if (funcionario is null)
            {
                throw new FuncionarioNaoEncontradoException("Funcionário não encontrado.");
            }

            return funcionario;
        }

        public async Task<Funcionario> AdicionarAsync(Funcionario funcionario)
        {
            return await repository.AdicionarAsync(funcionario);
        }

        public async Task<bool> UpdateAsync(Funcionario funcionario)
        {
            return await  repository.UpdateAsync(funcionario.Id, funcionario);
        }

        public async Task<bool> DeletarAsync(int id)
        {
            return await repository.DeletarAsync(id);
        }
    }
}