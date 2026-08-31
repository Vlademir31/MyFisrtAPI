using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Model;
using MyFirstAPI.Repository;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClientesController
    {
        private readonly ClienteRepository repository = new ClienteRepository();

        [HttpGet]
        public List<Cliente> ObterTodos()
        {
            return repository.ObterTodos();
        }

        [HttpGet]
        [Route("{id}")]
        public Cliente? ObterPorId([FromRoute] int id)
        {
            
            return repository.ObterPorId(id);
        }

        [HttpPost]
        public Cliente Criar([FromBody] Cliente cliente)
        {
            return repository.Adicionar(cliente);
        }

        [HttpPut]
        [Route("{id}")]
        public string Atualizar( [FromRoute] int id, [FromBody] Cliente clienteAtualizado)
        {
            bool atualizado = repository.Atualizar(id, clienteAtualizado);

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
            bool removido = repository.Remover(id);

            if (!removido)
            {
                return "Cliente não encontrado";
            }

            return "Cliente removido";
        }
    }
}