using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Interfaces;
using MyFirstAPI.Model;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("funcionarios")]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioService funcionarioService;

        public FuncionariosController(IFuncionarioService funcionarioService)
        {
            this.funcionarioService = funcionarioService;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(funcionarioService.ObterTodos());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult ObterPorId([FromRoute] int id)
        {
            Funcionario? funcionario = funcionarioService.ObterPorId(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return Ok(funcionario);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Funcionario funcionario)
        {
            Funcionario novoFuncionario = funcionarioService.Adicionar(funcionario);

            return Created("", novoFuncionario);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Atualizar(
            [FromRoute] int id,
            [FromBody] Funcionario funcionarioAtualizado)
        {
            funcionarioAtualizado.Id = id;

            bool atualizado = funcionarioService.Atualizar(funcionarioAtualizado);

            if (!atualizado)
            {
                return NotFound();
            }

            return Ok("Funcionário atualizado");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            bool removido = funcionarioService.Deletar(id);

            if (!removido)
            {
                return NotFound();
            }

            return Ok("Funcionário removido");
        }
    }
}