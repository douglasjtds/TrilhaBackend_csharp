using Clientes.Application.Interfaces;
using Clientes.Dominio.Entidades;
using Clientes.Dominio.Repositorios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

namespace Clientes.Application.UseCases
{
    public class ComicUseCase : IComicUseCase
    {
        private readonly ILogger<ComicUseCase> _logger;
        private readonly IConfiguration _config;
        private readonly IComicRepositorio _comicRepositorio;

        public ComicUseCase(ILogger<ComicUseCase> logger, IComicRepositorio comicRepositorio)
        {
            _logger = logger;
            _comicRepositorio = comicRepositorio;
        }

        public IList<Comic> Execute(string hero)
        {
            try
            {
                var comics = _comicRepositorio.Get(hero);
                _comicRepositorio.Salvar(comics);

                return comics;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }
    }
}
