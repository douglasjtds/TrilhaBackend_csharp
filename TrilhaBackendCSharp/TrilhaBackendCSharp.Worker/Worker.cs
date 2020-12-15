using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TrilhaBackendCSharp.Application.UseCases;
using TrilhaBackendCSharp.Dominio.Entidades;
using TrilhaBackendCSharp.Dominio.Repositorios;

namespace TrilhaBackendCSharp.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        
        //private readonly IEscreverArquivoRepositorio _escreverArquivoRepositorio;  //---------------acho que fiz confusão nessa parte, já que tem o UseCase, melhor remover isso?
        private readonly IGerarRelatorioUseCase _useCase;


        public Worker(ILogger<Worker> logger, IGerarRelatorioUseCase useCase) //IEscreverArquivoRepositorio escreverArquivoRepositorio)
        {
            _logger = logger;
            //_escreverArquivoRepositorio = escreverArquivoRepositorio;
            _useCase = useCase;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(100000, stoppingToken);

                _useCase.Execute();
            }
        }
    }
}
