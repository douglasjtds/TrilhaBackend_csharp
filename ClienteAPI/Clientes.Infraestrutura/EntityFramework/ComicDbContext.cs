using Clientes.Dominio.Entidades;
using Clientes.Infraestrutura.EntityFramework.Interfaces;
using Clientes.Infraestrutura.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Infraestrutura.EntityFramework
{
    public class ComicDbContext : DbContext, IComicDbContext
    {
        public ComicDbContext(DbContextOptions<ComicDbContext> options)
            : base(options)
        {

        }

        public DbSet<Comic> Comics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ComicMap());
        }
    }
}
