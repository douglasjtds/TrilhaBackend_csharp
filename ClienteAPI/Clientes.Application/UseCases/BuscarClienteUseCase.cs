using Clientes.Dominio.Entidades;
using Clientes.Dominio.Repositorios;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Clientes.Application.UseCases
{
    public class BuscarClienteUseCase : IBuscarClienteUseCase
    {
        private readonly ILogger<BuscarClienteUseCase> _logger;
        private readonly IClienteRepositorio _clienteRepositorio;

        public BuscarClienteUseCase(ILogger<BuscarClienteUseCase> logger, IClienteRepositorio clienteRepositorio)
        {
            _logger = logger;
            _clienteRepositorio = clienteRepositorio;
        }

        public IList<Cliente> Execute(string cpf = "")
        {
            try
            {
                if (!string.IsNullOrEmpty(cpf))
                {
                    List<Cliente> clientes = new List<Cliente>();
                    var teste = _clienteRepositorio.Get(cpf);
                    clientes.Add(teste);
                    return clientes;
                }
                return _clienteRepositorio.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }
    }
}
