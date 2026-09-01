using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Model;
using MyFirstAPI.Services;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClientesController
    {
        private readonly ClienteService clienteService = new ClienteService();

        [HttpGet]
        public List<Cliente> ObterTodos()
        {
            return clienteService.ObterTodos();
        }

        [HttpGet]
        [Route("{id}")]
        public Cliente? ObterPorId([FromRoute] int id)
        {
            
            return clienteService.ObterPorId(id);
        }

        [HttpPost]
        public Cliente Criar([FromBody] Cliente cliente)
        {
            return clienteService.Adicionar(cliente);
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