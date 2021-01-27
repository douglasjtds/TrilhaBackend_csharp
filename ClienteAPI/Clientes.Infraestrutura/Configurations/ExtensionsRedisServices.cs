using Clientes.Infraestrutura.Interfaces;
using Clientes.Infraestrutura.Repositorios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Clientes.Infraestrutura.Configurations
{
    public static class ExtensionsRedisServices
    {
        public static void ConfigureRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Config>(configuration.GetSection("Redis"));
            services.AddSingleton(typeof(ConnectionMultiplexer), sp => ConnectionMultiplexer.Connect(configuration["Redis:ConnectionString"]));
            services.AddScoped(typeof(ICacheRepository<>), typeof(RedisCacheRepository<>));
        }
    }
}
