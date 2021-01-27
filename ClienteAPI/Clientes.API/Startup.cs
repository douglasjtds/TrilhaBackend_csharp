using Clientes.Application.Interfaces;
using Clientes.Application.UseCases;
using Clientes.Dominio.Repositorios;
using Clientes.Infraestrutura.Configurations;
using Clientes.Infraestrutura.Decorator;
using Clientes.Infraestrutura.EntityFramework.Repositorios;
using Clientes.Infraestrutura.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Clientes.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.ConfigureDatabase(Configuration);
            services.ConfigureRedis(Configuration);

            services.RegisterRepository();
            services.AddTransient<IBuscarClienteUseCase, BuscarClienteUseCase>();
            services.AddTransient<ISalvarClienteUseCase, SalvarClienteUseCase>();
            services.AddTransient<IRemoverClienteUseCase, RemoverClienteUseCase>();
            services.AddTransient<IComicRepositorio, ComicRepositorio>();
            services.AddTransient<IComicUseCase, ComicUseCase>();
            services.Configure<CacheDuration>(Configuration.GetSection("Redis:CacheDuration"));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cliente API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
