using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TrilhaBackendCSharp.Dominio.Repositorios;
using TrilhaBackendCSharp.Infraestrutura.Repositorios;

namespace TrilhaBackendCSharp.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IEscreverArquivoRepositorio _escreverArquivoRepositorio;


        public Worker(ILogger<Worker> logger, IClienteRepositorio clienteRepositorio, IEscreverArquivoRepositorio escreverArquivoRepositorio)
        {
            _logger = logger;
            _clienteRepositorio = clienteRepositorio;
            _escreverArquivoRepositorio = escreverArquivoRepositorio;
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

            //Desafio 2: Fazer um foreach que vai ler os clientes e escrever num txt (classe IO)
            _escreverArquivoRepositorio.Escreve(listaClientes);
            //Desafio 3: Parametrizar no appsetings o tempo de delay e o caminho onde vai salvar o arquivo
            //Desafio 4: loggar erro caso der uma exceção usando o _logger

            //possiveis erros, caminho existir
        }
    }
}
