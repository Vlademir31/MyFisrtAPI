using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Model;

namespace MyFirstAPI.Data
{
    public class MyFirstApiContext : DbContext
    {
        public MyFirstApiContext(DbContextOptions<MyFirstApiContext> options) : base(options)
        {
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
    