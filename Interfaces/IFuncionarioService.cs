
using MyFirstAPI.Model;

namespace MyFirstAPI.Interfaces
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<Funcionario>> ObterTodosAsync();

        Task<Funcionario?> ObterPorIdAsync(int id);

        Task<Funcionario> AdicionarAsync(Funcionario funcionario );

        Task<bool> UpdateAsync(Funcionario funcionario);

        Task<bool> DeletarAsync(int id);
    }
}