using MyFirstAPI.Model;


namespace MyFirstAPI.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task<List<Funcionario>> ObterTodosAsync();

       Task<Funcionario?> ObterPorIdAsync(int id);

        Task<Funcionario> AdicionarAsync(Funcionario funcionario);

        Task<bool> UpdateAsync(int id, Funcionario funcionario);

        Task<bool> DeletarAsync(int id);
    }
}