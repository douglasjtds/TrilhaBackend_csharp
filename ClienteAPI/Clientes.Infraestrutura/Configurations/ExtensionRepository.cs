using Clientes.Dominio.Repositorios;
using Clientes.Infraestrutura.Decorator;
using Clientes.Infraestrutura.EntityFramework.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Clientes.Infraestrutura.Configurations
{
    public static class ExtensionRepository
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services)
        {
            services.AddTransient<IClienteRepositorio, ClienteRepositorio>()
                .Decorate<IClienteRepositorio, ClienteRepositorioCache>();

            return services;
        }
    }
}
