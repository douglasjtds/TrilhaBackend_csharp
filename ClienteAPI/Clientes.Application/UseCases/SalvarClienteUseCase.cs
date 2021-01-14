using Clientes.Application.Interfaces;
using Clientes.Dominio.Entidades;
using Clientes.Dominio.Repositorios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace Clientes.Application.UseCases
{
    public class SalvarClienteUseCase : ISalvarClienteUseCase
    {
        private readonly ILogger<SalvarClienteUseCase> _logger;
        private readonly IConfiguration _configuration;
        private readonly IClienteRepositorio _clienteRepositorio;

        public SalvarClienteUseCase(ILogger<SalvarClienteUseCase> logger, IConfiguration configuration, IClienteRepositorio clienteRepositorio)
        {
            _logger = logger;
            _configuration = configuration;
            _clienteRepositorio = clienteRepositorio;
        }

        public void Execute(Cliente cliente, string cpf = "")
        {
            try
            {
                if (string.IsNullOrEmpty(cpf))
                {
                    _clienteRepositorio.Adicionar(cliente);
                }
                else
                {
                    if (cpf != cliente.CPF)
                    {
                        _logger.LogError("Não é permitido alterar o CPF de um cliente já cadastrado. Já existe um cliente com o CPF: {0}", cpf);
                    }
                    _clienteRepositorio.Atualizar(cpf, cliente);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
    }
}
