using Clientes.Dominio.Entidades;
using Clientes.Dominio.Repositorios;
using Clientes.Infraestrutura.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Clientes.Infraestrutura.Repositorios
{
    public class ComicRepositorio : IComicRepositorio
    {
        private readonly ClientesDbContext _comicDbContext;
        private readonly ILogger<ComicRepositorio> _logger;

        public ComicRepositorio(ClientesDbContext comicDbContext, ILogger<ComicRepositorio> logger, IConfiguration config)
        {
            _logger = logger;
            _comicDbContext = comicDbContext;
        }

        public bool Salvar(IList<Comic> comics)
        {
            try
            {
                foreach (var comic in comics)
                {
                    _comicDbContext.Comics.Add(comic);
                    _comicDbContext.SaveChanges();
                }
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
