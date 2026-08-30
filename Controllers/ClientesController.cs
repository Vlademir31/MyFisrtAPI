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
}
