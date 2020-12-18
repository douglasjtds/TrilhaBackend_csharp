using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using TrilhaBackendCSharp.Dominio.Repositorios;

namespace TrilhaBackendCSharp.Application.UseCases
{
    public class GerarRelatorioUseCase : IGerarRelatorioUseCase
    {
        private readonly ILogger<GerarRelatorioUseCase> _logger;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IConfiguration _configuration;

        public GerarRelatorioUseCase(ILogger<GerarRelatorioUseCase> logger, IClienteRepositorio clienteRepositorio, IConfiguration configuration)
        {
            _logger = logger;
            _clienteRepositorio = clienteRepositorio;
            _configuration = configuration;
        }

        public void Execute()
        {
            try
            {
                //Desafio 1: Consultar no banco os clientes
                var listaClientes = _clienteRepositorio.Consultar();

                var path = _configuration.GetSection(@"Integracao:CaminhoArquivo").Value;
                var fileName = string.Concat("clientes_", DateTime.Now.ToString("ddMMyyyy"), ".txt");

                if (!File.Exists(string.Concat(path, fileName)))
                    File.Create(string.Concat(path, fileName)).Close();

                using (StreamWriter file = new StreamWriter(string.Concat(path, fileName)))
                {
                    //Desafio 2: Fazer um foreach que vai ler os clientes e escrever num txt (classe IO)
                    foreach (var cliente in listaClientes)
                    {
                        file.WriteLine(cliente.Imprimir);
                    }
                }

                //Desafio 3: Parametrizar no appsetings o tempo de delay e o caminho onde vai salvar o arquivo
                //feito

                //possiveis erros, caminho existir ou não...
            }
            //Desafio 4: loggar erro caso der uma exceção usando o _logger (dá pra melhorar ainda)
            catch (Exception ex)
            {
                _logger.LogError(ex, " Erro ao salvar arquivo: {0}", ex.Message);
            }
        }
    }
}
