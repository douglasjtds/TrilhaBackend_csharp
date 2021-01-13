using Clientes.Dominio.Entidades;
using Clientes.Infraestrutura.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Clientes.Infraestrutura.EntityFramework.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly ClientesDbContext _clientesDbContext;
        private readonly ILogger<ClienteRepositorio> _logger;

        public ClienteRepositorio(ClientesDbContext clientesDbContext, ILogger<ClienteRepositorio> logger)
        {
            _clientesDbContext = clientesDbContext;
            _logger = logger;
        }

        #region CREATE
        public void Adicionar(Cliente cliente)
        {
            try
            {
                _clientesDbContext.Clientes.Add(cliente);
                _logger.LogInformation("Cliente adicionado com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
        #endregion

        #region READ
        public Cliente Get(string cpf)
        {
            try
            {
                return _clientesDbContext.Clientes.Where(p => p.CPF == cpf).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public IEnumerable<Cliente> GetAll()
        {
            try
            {
                return _clientesDbContext.Clientes;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }
        #endregion

        #region UPDATE
        public void Atualizar(Cliente cliente)
        {
            try
            {
                _clientesDbContext.Entry(cliente).State = EntityState.Modified;
                _logger.LogInformation("Cliente alterado com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
        #endregion

        #region DELETE
        public void Excluir(string cpf)
        {
            try
            {
                Cliente cliente = _clientesDbContext.Clientes.Where(p => p.CPF == cpf).FirstOrDefault();
                _clientesDbContext.Clientes.Remove(cliente);
                _logger.LogInformation("Cliente removido com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }

        public void Salvar()
        {
            try
            {
                _clientesDbContext.SaveChanges();
                _logger.LogInformation("Alterações salvas com sucesso na base.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
        #endregion

    }
}
