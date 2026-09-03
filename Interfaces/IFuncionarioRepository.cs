using MyFirstAPI.Model;


namespace MyFirstAPI.Interfaces
{
    public interface IFuncionarioRepository
    {
        List<Funcionario> ObterTodos();

        Funcionario? ObterPorId(int id);

        Funcionario Adicionar(Funcionario funcionario);

        bool Atualizar(int id, Funcionario funcionario);

        bool Remover(int id);
    }
}