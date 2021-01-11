using Clientes.Dominio.Entidades;
using Clientes.Infraestrutura.EntityFramework.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Infraestrutura.EntityFramework
{
    public class ClientesDbContext : DbContext
    {
        //public DbSet<ClienteRepositorio> ClienteRepositorio { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        //private readonly bool UseTempDB = true;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ClienteRepositorioMap());
        }
    }
}
