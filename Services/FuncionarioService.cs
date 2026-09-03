
using MyFirstAPI.Interfaces;
using MyFirstAPI.Model;

namespace MyFirstAPI.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository repository;

        public FuncionarioService(IFuncionarioRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Funcionario> ObterTodos()
        {
            return repository.ObterTodos();
        }

        public Funcionario? ObterPorId(int id)
        {
            return repository.ObterPorId(id);
        }

        public Funcionario Adicionar(Funcionario funcionario)
        {
            return repository.Adicionar(funcionario);
        }

        public bool Atualizar(Funcionario funcionario)
        {
            return repository.Atualizar(funcionario.Id, funcionario);
        }

        public bool Deletar(int id)
        {
            return repository.Remover(id);
        }
    }
}