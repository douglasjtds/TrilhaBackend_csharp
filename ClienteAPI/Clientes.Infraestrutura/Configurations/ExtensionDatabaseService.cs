using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Clientes.Infraestrutura.Configurations
{
    public static class ExtensionDatabaseService
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection service, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("ClientesDatabase");
            service.AddSingleton(provider => new Func<IDbConnection>(() => new SqlConnection(connectionString)));
            return service;
        }
    }
}
