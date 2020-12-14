using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TrilhaBackendCSharp.Dominio.Entidades;
using TrilhaBackendCSharp.Dominio.Repositorios;

namespace TrilhaBackendCSharp.Application.UseCases
{
    public class GerarRelatorioUseCase : IGerarRelatorioUseCase
    {
        private readonly ILogger<GerarRelatorioUseCase> _logger;
        private readonly IEscreverArquivoRepositorio _escreverArquivoRepositorio;

        public GerarRelatorioUseCase(ILogger<GerarRelatorioUseCase> logger, IEscreverArquivoRepositorio escreverArquivoRepositorio)
        {
            _logger = logger;
            _escreverArquivoRepositorio = escreverArquivoRepositorio;
        }

        public void Execute(List<Cliente> listaDeClientes)
        {
            try
            {
                //Desafio 2: Fazer um foreach que vai ler os clientes e escrever num txt (classe IO)
                _escreverArquivoRepositorio.Escreve(listaDeClientes);
                //TO-DO: voltar isso para o UseCase


                //Desafio 3: Parametrizar no appsetings o tempo de delay e o caminho onde vai salvar o arquivo


                //possiveis erros, caminho existir
            }
            //Desafio 4: loggar erro caso der uma exceção usando o _logger
            catch (Exception ex)
            {
                _logger.LogError(ex, " Erro ao salvar arquivo: {0}", ex.Message);
            }
        }
    }
}
