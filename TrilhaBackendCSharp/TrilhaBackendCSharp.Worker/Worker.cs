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
        private readonly IClienteRepositorio _clienteRepositorio;
        //private readonly IEscreverArquivoRepositorio _escreverArquivoRepositorio;  //---------------acho que fiz confusão nessa parte, já que tem o UseCase, melhor remover isso?
        private readonly IGerarRelatorioUseCase _useCase;


        public Worker(ILogger<Worker> logger, IClienteRepositorio clienteRepositorio, IGerarRelatorioUseCase useCase) //IEscreverArquivoRepositorio escreverArquivoRepositorio)
        {
            _logger = logger;
            _clienteRepositorio = clienteRepositorio;
            //_escreverArquivoRepositorio = escreverArquivoRepositorio;
            _useCase = useCase;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(10000, stoppingToken);
            }

            //Desafio 1: Consultar no banco os clientes
            var listaClientes = _clienteRepositorio.Consultar();
            _useCase.Execute(listaClientes);
        }
    }
}
