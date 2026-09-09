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
        public async Task<IActionResult> ObterTodosAsync()
        {
            var funcionarios = await funcionarioService.ObterTodosAsync();
            return Ok(funcionarios);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObterPorIdAsync([FromRoute] int id)
        {
            Funcionario? funcionario = await funcionarioService.ObterPorIdAsync(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return Ok(funcionario);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] Funcionario funcionario)
        {
            Funcionario novoFuncionario = await funcionarioService.AdicionarAsync(funcionario);

            return CreatedAtAction("ObterPorId", new { id = novoFuncionario.Id }, novoFuncionario);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync(
            [FromRoute] int id,
            [FromBody] Funcionario funcionarioUpdate)
        {
            funcionarioUpdate.Id = id;

            bool Update = await funcionarioService.UpdateAsync(funcionarioUpdate);

            if (!Update)
            {
                return NotFound();
            }

            return Ok("Funcionário atualizado");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletarAsync([FromRoute] int id)
        {
            bool removido = await funcionarioService.DeletarAsync(id);

            if (!removido)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}