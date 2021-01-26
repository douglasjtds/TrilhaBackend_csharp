using Clientes.Dominio.Entidades;
using Clientes.Dominio.Repositorios;
using Clientes.Infraestrutura.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Clientes.Infraestrutura.Repositorio
{
    public class ComicRepositorio : IComicRepositorio
    {
        private readonly ClientesDbContext _comicDbContext;
        private readonly ILogger<ComicRepositorio> _logger;
        private readonly IConfiguration _config;

        public ComicRepositorio(ClientesDbContext comicDbContext, ILogger<ComicRepositorio> logger, IConfiguration config)
        {
            _logger = logger;
            _comicDbContext = comicDbContext;
            _config = config;
        }

        public object Get(string hero)
        {
            throw new NotImplementedException();
        }

        //public IList<Comic> Get(string hero)
        //{

        //}

        public bool Salvar(Comic comic)
        {
            try
            {
                _comicDbContext.Comics.Add(comic);
                _comicDbContext.SaveChanges();
                _logger.LogInformation("Quadrinho salvo com sucesso.");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }
    }
}
