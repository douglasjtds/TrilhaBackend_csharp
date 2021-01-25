using Clientes.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Clientes.Infraestrutura.EntityFramework.Interfaces;
using Clientes.Infraestrutura.EntityFramework.Mappers;

namespace Clientes.Infraestrutura.EntityFramework
{
    public class ClientesDbContext : DbContext, IClientesDbContext
    {
        public ClientesDbContext(DbContextOptions<ClientesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Comic> Comics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ComicMap());
        }
    }
}
