using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Data;
using MyFirstAPI.Interfaces;
using MyFirstAPI.Model;

namespace MyFirstAPI.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly MyFirstApiContext context;

        public FuncionarioRepository(MyFirstApiContext context)
        {
            this.context = context;
        }

        public List<Funcionario> ObterTodos()
        {
            return context.Funcionarios.ToList();
        }

        public Funcionario? ObterPorId(int id)
        {
            return context.Funcionarios.FirstOrDefault(f => f.Id ==id);
        }

        public Funcionario Adicionar(Funcionario funcionario)
        {
            context.Funcionarios.Add(funcionario);
            context.SaveChanges();
            return funcionario;
        }

        public bool Update(int id, Funcionario funcionarioUpdate)
        {
            Funcionario? funcionario = context.Funcionarios.FirstOrDefault(f => f.Id == id);

            if(funcionario == null)
            {
                return false;
            }

            funcionario.Nome = funcionarioUpdate.Nome;
            funcionario.Cpf = funcionarioUpdate.Cpf;
            funcionario.Email = funcionarioUpdate.Email;
            funcionario.Telefone = funcionarioUpdate.Telefone;
            funcionario.Cargo = funcionarioUpdate.Cargo;
            funcionario.Departamento = funcionarioUpdate.Departamento;
            funcionario.DataAdmissao = funcionarioUpdate.DataAdmissao;
            funcionario.Ativo = funcionarioUpdate.Ativo;

            context.SaveChanges();

            return true;
        }

        public bool Remover(int id)
        {
            return false;
        }
    }
}