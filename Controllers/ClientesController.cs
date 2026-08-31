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
        public string Criar([FromBody] Cliente cliente)
        {
            clientes.Add(cliente);

            return "cliente cadastrado";
        }
    }
}