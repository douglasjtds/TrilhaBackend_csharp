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

        public GerarRelatorioUseCase(ILogger<GerarRelatorioUseCase> logger, IClienteRepositorio clienteRepositorio)
        {
            _logger = logger;
            _clienteRepositorio = clienteRepositorio;
        }

        public void Execute()
        {
            try
            {
                //Desafio 1: Consultar no banco os clientes
                var listaClientes = _clienteRepositorio.Consultar();

                //Desafio 2: Fazer um foreach que vai ler os clientes e escrever num txt (classe IO)
                foreach (var cliente in listaClientes)
                {
                    //escrever no arquivo txt
                    //TO-DO: usar caminho dinamico no appsettings
                    var filePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) +
                        @"\TrilhaBackend_csharp\";

                    Directory.CreateDirectory(filePath);
                    filePath += "clientes.txt";
                    File.Create(filePath);
                    File.AppendAllText(filePath, cliente.Imprimir + "\n");
                }

                //Desafio 3: Parametrizar no appsetings o tempo de delay e o caminho onde vai salvar o arquivo

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
