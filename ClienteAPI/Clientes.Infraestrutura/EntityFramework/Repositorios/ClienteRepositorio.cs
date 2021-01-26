using Clientes.Dominio.Entidades;
using Clientes.Dominio.Repositorios;
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
                _clientesDbContext.SaveChanges();
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

        public IList<Cliente> GetAll()
        {
            try
            {
                return _clientesDbContext.Clientes.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }
        #endregion

        #region UPDATE
        public bool Atualizar(string cpfRecebido, Cliente cliente)
        {
            try
            {
                if (_clientesDbContext.Clientes.Any(c => c.CPF == cpfRecebido))
                {
                    //_clientesDbContext.Entry(cliente).State = EntityState.Modified;
                    _clientesDbContext.Clientes.Update(cliente);
                    _clientesDbContext.SaveChanges();
                    _logger.LogInformation("Cliente alterado com sucesso.");
                    return true;
                }
                else
                {
                    _logger.LogWarning("Não foi encontrado um cliente com esse CPF na base.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }
        #endregion

        #region DELETE
        public bool Excluir(string cpf)
        {
            try
            {
                if (_clientesDbContext.Clientes.Any(c => c.CPF == cpf))
                {
                    Cliente cliente = _clientesDbContext.Clientes.Where(p => p.CPF == cpf).FirstOrDefault();
                    _clientesDbContext.Clientes.Remove(cliente);
                    _clientesDbContext.SaveChanges();
                    _logger.LogInformation("Cliente removido com sucesso.");
                    return true;
                }
                else
                {
                    _logger.LogWarning("Não foi encontrado um cliente com esse CPF na base.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }
        #endregion

    }
}
