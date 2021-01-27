using Clientes.Infraestrutura.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clientes.Infraestrutura.Configurations
{
    public static class ExtensionDatabaseService
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection service, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("ClientesDatabase");
            service.AddDbContext<ClientesDbContext>(options => options.UseSqlServer(connectionString));
            return service;
        }
    }
}
