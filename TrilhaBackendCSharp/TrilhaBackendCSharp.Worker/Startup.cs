﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrilhaBackendCSharp.Infraestrutura.Configurations;

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
            services.ConfigureDatabase(Configuration);
        }

        public void Configure(IApplicationBuilder app)
        {

        }
    }
}