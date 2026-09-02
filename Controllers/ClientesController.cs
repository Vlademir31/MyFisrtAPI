using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Model;
using MyFirstAPI.Services;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClientesController : Controller
    {
        private readonly ClienteService clienteService;
        public ClientesController(ClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        [HttpGet]
        public List<Cliente> ObterTodos()
        {
            return clienteService.ObterTodos();
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
        public string Atualizar( [FromRoute] int id, [FromBody] Cliente clienteAtualizado)
        {
            bool atualizado = clienteService.Atualizar(id, clienteAtualizado);

            if (!atualizado)
            {
                return "Cliente não encontrado";
            }

            return "cliente atualizado";
        }
        [HttpDelete]
        [Route("{id}")]
        public string Deletar ([FromRoute] int id)
        {
            bool removido = clienteService.Deletar(id);

            if (!removido)
            {
                return "Cliente não encontrado";
            }

            return "Cliente removido";
        }
    }
}