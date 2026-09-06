using MyFirstAPI.Model;
using MyFirstAPI.Interfaces;
using MyFirstAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace MyFirstAPI.Repository
{
    public class ClienteRepository : IClienteRepository 
    {
        private readonly MyFirstApiContext context;

        public ClienteRepository(MyFirstApiContext context)
        {
            this.context = context;
        }

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
        public List<Cliente> ObterTodos()
        {
            return context.Clientes.ToList();
        }
        
        public Cliente? ObterPorId(int id)
        {
            return context.Clientes.FirstOrDefault(c => c.Id == id);
        }
        public Cliente Adicionar(Cliente cliente)
        {
         context.Clientes.Add(cliente);
         context.SaveChanges();
            return cliente;
        }
        public bool Update (int id, Cliente clienteAtualizado)
        {
            Cliente? cliente = context.Clientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                return false;
            }

            cliente.Nome = clienteAtualizado.Nome;
            cliente.Email = clienteAtualizado.Email;

            context.SaveChanges();

            return true;
        }


        public bool Remover(int id)
        {
            Cliente? cliente = context.Clientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                return false;
            }

            context.Clientes.Remove(cliente);
            context.SaveChanges();

            return true;
        }
    
    }   
}   
