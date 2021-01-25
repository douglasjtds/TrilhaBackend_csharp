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
        private readonly ComicDbContext _clientesDbContext;
        private readonly ILogger<ComicRepositorio> _logger;
        private readonly IConfiguration _config;

        public ComicRepositorio(ComicDbContext clientesDbContext, ILogger<ComicRepositorio> logger, IConfiguration config)
        {
            _logger = logger;
            _clientesDbContext = clientesDbContext;
            _config = config;
        }

        public object Get(string hero)
        {
            throw new NotImplementedException();
        }

        //public IList<Comic> Get(string hero)
        //{

        //}

        public bool Salvar(IList<Comic> comics)
        {
            try
            {
                foreach (var comic in comics)
                {
                    _clientesDbContext.Comics.Add(comic);
                    _clientesDbContext.SaveChanges();
                    _logger.LogInformation("Quadrinho salvo com sucesso.");
                }
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
