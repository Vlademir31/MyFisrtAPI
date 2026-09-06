
using MyFirstAPI.Model;

namespace MyFirstAPI.Interfaces
{
    public interface IFuncionarioService
    {
        IEnumerable<Funcionario> ObterTodos();

        Funcionario? ObterPorId(int id);

        Funcionario Adicionar(Funcionario funcionario );

        bool Update(Funcionario funcionario);

        bool Deletar(int id);
    }
}