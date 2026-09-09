using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Model;
using MyFirstAPI.Interfaces;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService clienteService;
        public ClientesController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            return Ok (await clienteService.ObterTodosAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObterPorIdAsync([FromRoute] int id)
        {
            
            Cliente? cliente = await clienteService.ObterPorIdAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok (cliente);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] Cliente cliente)
        {
            Cliente novoCliente = await clienteService.AdicionarAsync(cliente);
            return CreatedAtAction("ObterPorId", new { id = novoCliente.Id }, novoCliente);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync( [FromRoute] int id, [FromBody] Cliente clienteUpdate)
        {
            clienteUpdate.Id = id;
            
            bool atualizado = await clienteService.UpdateAsync(clienteUpdate);

            if (!atualizado)
            {
                return NotFound();
            }

            return Ok("cliente atualizado");
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Deletar ([FromRoute] int id)
        {
            bool removido = await clienteService.DeletarAsync(id);

            if (!removido)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}