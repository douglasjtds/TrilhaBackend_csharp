using Clientes.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Infraestrutura.EntityFramework.Interfaces
{
    public interface IClientesDbContext
    {
        DbSet<Cliente> Clientes { get; set; }
    }
}
