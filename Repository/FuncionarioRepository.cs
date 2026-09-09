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

        public Task<List<Funcionario>>  ObterTodosAsync()
        {
            return context.Funcionarios.ToListAsync();
        }

        public Task<Funcionario?> ObterPorIdAsync(int id)
        {
            return context.Funcionarios.FirstOrDefaultAsync(f => f.Id ==id);
        }

        public async Task<Funcionario> AdicionarAsync(Funcionario funcionario)
        {
            context.Funcionarios.Add(funcionario);
            await context.SaveChangesAsync();
            return funcionario;
        }

        public async Task<bool> UpdateAsync(int id, Funcionario funcionarioUpdate)
        {
            Funcionario? funcionario = await context.Funcionarios.FirstOrDefaultAsync(f => f.Id == id);

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

           await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            Funcionario? funcionario = await context.Funcionarios.FirstOrDefaultAsync(f => f.Id == id);

            if (funcionario == null)
            {
                return false;
            }
           
            context.Funcionarios.Remove(funcionario);

              await context.SaveChangesAsync();

               return true;
        }
    }
}