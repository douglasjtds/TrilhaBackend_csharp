using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrilhaBackendCSharp.Application.UseCases;
using TrilhaBackendCSharp.Dominio.Entidades;
using TrilhaBackendCSharp.Dominio.Repositorios;
using TrilhaBackendCSharp.Infraestrutura.Configurations;
using TrilhaBackendCSharp.Infraestrutura.Repositorios;

namespace TrilhaBackendCSharp.Worker
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IEscreverArquivoRepositorio, EscreverArquivoRepositorio>();
            services.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            services.AddTransient<IGerarRelatorioUseCase, GerarRelatorioUseCase>();
            services.ConfigureDatabase(Configuration);
        }

        public void Configure(IApplicationBuilder app)
        {

        }
    }
}
