using MyFirstAPI.Model;

namespace MyFirstAPI.Repository
{
    public class ClienteRepository
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
        public List<Cliente> ObterTodos()
        {
            return clientes;
        }
        private static int proximoId = 3;

        public Cliente? ObterPorId(int id)
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
        public Cliente Adicionar(Cliente cliente)
        {
            cliente.Id = proximoId;
            proximoId++;

            clientes.Add(cliente);

            return cliente;
        }
        public bool Atualizar (int id, Cliente clienteAtualizado)
        {
            Cliente? cliente = ObterPorId(id);

            if (cliente == null)
            {
                return false;
            }

            cliente.Nome = clienteAtualizado.Nome;
            cliente.Email = clienteAtualizado.Email;

            return true;
        }


        public bool Remover(int id)
        {
            Cliente? cliente = ObterPorId(id);

            if (cliente == null)
            {
                return false;
            }

            clientes.Remove(cliente);

            return true;
        }
    
    }   
}   
