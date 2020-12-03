using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TrilhaBackendCSharp.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(10000, stoppingToken);
            }

            //Desafio 1: Consultar no banco os clientes
            //Desafio 2: Fazer um foreach que vai ler os clientes e escrever num txt (classe IO)
            //Desafio 3: Parametrizar no appsetings o tempo de delay e o caminho onde vai salvar o arquivo
            //Desafio 4: loggar erro caso der uma exceção usando o _logger

            //possiveis erros, caminho existir
        }
    }
}
