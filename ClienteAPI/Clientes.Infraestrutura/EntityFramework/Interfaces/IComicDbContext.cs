using Clientes.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Infraestrutura.EntityFramework.Interfaces
{
    public interface IComicDbContext
    {
        DbSet<Comic> Comics { get; set; }
    }
}
