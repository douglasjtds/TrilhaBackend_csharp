using Clientes.Dominio.Entidades;
using Clientes.Dominio.Repositorios;
using Clientes.Infraestrutura.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace Clientes.Infraestrutura.Repositorio
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
