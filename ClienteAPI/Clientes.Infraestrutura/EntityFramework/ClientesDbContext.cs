using Clientes.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Infraestrutura.EntityFramework
{
    public class ClientesDbContext : DbContext
    {

        public ClientesDbContext(DbContextOptions<ClientesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
