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
        public Task<List<Cliente>> ObterTodosAsync()
        {
            return context.Clientes.ToListAsync();
        }
        
        public Task<Cliente?> ObterPorIdAsync(int id)
        {
            return context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Cliente> AdicionarAsync(Cliente cliente)
        {
         context.Clientes.Add(cliente);
         await context.SaveChangesAsync();

            return cliente;
        }
        public async Task<bool> UpdateAsync (int id, Cliente clienteAtualizado)
        {
            Cliente? cliente = await context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
            {
                return false;
            }

            cliente.Nome = clienteAtualizado.Nome;
            cliente.Email = clienteAtualizado.Email;

            context.SaveChanges();

            return true;
        }


        public async Task<bool> RemoverAsync(int id)
        {
            Cliente? cliente = await context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
            {
                return false;
            }

            context.Clientes.Remove(cliente);
            await context.SaveChangesAsync();

            return true;
        }
    
    }   
}   
