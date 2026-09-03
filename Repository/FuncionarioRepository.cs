using MyFirstAPI.Model;
using MyFirstAPI.Interfaces;

namespace MyFirstAPI.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private List<Funcionario> funcionarios = new List<Funcionario>
      {
        new Funcionario
        {
            Id = 1,
            Nome = "Vlade",
            Cpf = "123.456.789-12",
            Email = "vlade@gmail.com",
            Telefone = "(47) 9 9999-9999",
            Cargo = "Consultor",
            Departamento = "Consultoria",
            DataAdmissao = new DateTime(2026, 01, 10),
            Ativo = true
        }
      };
    
    private static int proximoId = 2;
    public List<Funcionario> ObterTodos()
    {
        return funcionarios;
    }
    public Funcionario? ObterPorId(int id)
    {
        Funcionario? resultado = null;

        foreach (var funcionario in funcionarios)
        {
            if (funcionario.Id == id)
            {
                resultado = funcionario;
                break;
            }
        }

        return resultado;
    }
    public Funcionario Adicionar(Funcionario funcionario)
    {
        funcionario.Id = proximoId;
        proximoId++;

        funcionarios.Add(funcionario);

        return funcionario;
    }
    public bool Atualizar (int id, Funcionario funcionarioAtualizado)
        {
            Funcionario? funcionario = ObterPorId(id);

            if (funcionario == null)
            {
                return false;
            }
            funcionario.Nome = funcionarioAtualizado.Nome;
            funcionario.Cpf = funcionarioAtualizado.Cpf;
            funcionario.Email = funcionarioAtualizado.Email;
            funcionario.Telefone = funcionarioAtualizado.Telefone;
            funcionario.Cargo = funcionarioAtualizado.Cargo;
            funcionario.Departamento = funcionarioAtualizado.Departamento;
            funcionario.DataAdmissao = funcionarioAtualizado.DataAdmissao;
            funcionario.Ativo = funcionarioAtualizado.Ativo;

            return true;
        }
        public bool Remover(int id)
        {
            Funcionario? funcionario = ObterPorId(id);

            if (funcionario == null)
            {
                return false;
            }

            funcionarios.Remove(funcionario);

            return true;
        }
    }
}