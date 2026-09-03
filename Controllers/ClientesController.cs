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
        public IActionResult ObterTodos()
        {
            return Ok (clienteService.ObterTodos());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult ObterPorId([FromRoute] int id)
        {
            
            Cliente? cliente = clienteService.ObterPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok (cliente);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Cliente cliente)
        {
            Cliente novoCliente = clienteService.Adicionar(cliente);
            return Created("", novoCliente);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Atualizar( [FromRoute] int id, [FromBody] Cliente clienteAtualizado)
        {
            clienteAtualizado.Id = id;
            
            bool atualizado = clienteService.Atualizar(clienteAtualizado);

            if (!atualizado)
            {
                return NotFound();
            }

            return Ok("cliente atualizado");
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Deletar ([FromRoute] int id)
        {
            bool removido = clienteService.Deletar(id);

            if (!removido)
            {
                return NotFound();
            }

            return Ok("Cliente removido");
        }
    }
}