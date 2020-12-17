using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TrilhaBackendCSharp.Application.UseCases;

namespace TrilhaBackendCSharp.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IGerarRelatorioUseCase _useCase;
        private readonly IConfiguration _configuration;

        public Worker(ILogger<Worker> logger, IGerarRelatorioUseCase useCase, IConfiguration configuration)
        {
            _logger = logger;
            _useCase = useCase;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _useCase.Execute();
                var delay = Convert.ToInt32(_configuration.GetSection("Integracao:Delay").Value);
                await Task.Delay(delay, stoppingToken);
            }
        }
    }
}
