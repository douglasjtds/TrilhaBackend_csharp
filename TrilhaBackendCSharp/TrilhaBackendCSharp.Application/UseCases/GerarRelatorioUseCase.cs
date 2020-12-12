using System;
using System.Collections.Generic;
using TrilhaBackendCSharp.Dominio.Entidades;
using TrilhaBackendCSharp.Dominio.Repositorios;

namespace TrilhaBackendCSharp.Application.UseCases
{
    public class GerarRelatorioUseCase : IUseCase<Cliente>
    {
        private readonly IEscreverArquivoRepositorio _escreverArquivoRepositorio;

        public GerarRelatorioUseCase(IEscreverArquivoRepositorio escreverArquivoRepositorio)
        {
            _escreverArquivoRepositorio = escreverArquivoRepositorio;
        }

        public void Execute(List<Cliente> listaDeClientes)
        {
            //Desafio 2: Fazer um foreach que vai ler os clientes e escrever num txt (classe IO)
            _escreverArquivoRepositorio.Escreve(listaDeClientes);

            //Desafio 3: Parametrizar no appsetings o tempo de delay e o caminho onde vai salvar o arquivo
            //Desafio 4: loggar erro caso der uma exceção usando o _logger

            //possiveis erros, caminho existir
        }
    }
}
