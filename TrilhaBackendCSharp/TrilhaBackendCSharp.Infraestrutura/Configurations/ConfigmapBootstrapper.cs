using Microsoft.Extensions.Hosting;

namespace TrilhaBackendCSharp.Infraestrutura.Configurations
{
    public static class ConfigmapBootstrapper
    {
        public static IHostBuilder GetConfiguration(this IHostBuilder builder)
        {
            return builder;
        }
    }
}
