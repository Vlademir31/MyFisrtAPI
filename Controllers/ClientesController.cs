using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Model;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClientesController
    {
        private static List<Cliente> clientes = new List<Cliente>
       {
        new Cliente
            {
        Id = 1,
        Nome = "Vlademir",
        Email = "vlade@email.com"
    },

    new Cliente
    {
        Id = 2,
        Nome = "Maria",
        Email = "maria@email.com"
    }
};
private static int proximoId = 3;

        [HttpGet]
        public List<Cliente> ObterTodos()
        {
            return clientes;
        }

        [HttpGet]
        [Route("{id}")]
        public Cliente? ObterPorId([FromRoute] int id)
        {
            Cliente? resultado = null;

            foreach (var cliente in clientes)
            {
                if (cliente.Id == id)
                {
                    resultado = cliente;
                    break;
                }
            }
            return resultado;
        }
        [HttpPost]
        public Cliente Criar([FromBody] Cliente cliente)
        {
            cliente.Id = proximoId;

            proximoId++;

            clientes.Add(cliente);

            return cliente;
        }
        [HttpPut]
        [Route("{id}")]
        public string? Atualizar( [FromRoute] int id, [FromBody] Cliente clienteAtualizado)
        {
            Cliente? selecionado = ObterPorId(id);

            if (selecionado == null)
            {
                return "Cliente não encontrado";
            }

            selecionado.Nome = clienteAtualizado.Nome;
            selecionado.Email = clienteAtualizado.Email;

            return "Cliente ataulizado";
        }
        [HttpDelete]
        [Route("{id}")]
        public string? Deletar ([FromRoute] int id)
        {
            Cliente? cliente = ObterPorId(id);

            if (cliente == null)
            {
                return "Cliente não encontrado";
            }

            clientes.Remove(cliente);

            return "Cliente removido";
        }
    }
}