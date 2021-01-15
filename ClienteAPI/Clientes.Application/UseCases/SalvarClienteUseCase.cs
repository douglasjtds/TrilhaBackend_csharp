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

        public bool Execute(Cliente cliente, out string message, string cpf = "")
        {
            try
            {
                //não permitir salvar número no nome
                var isNumeric = int.TryParse(cliente.Nome, out _);
                if (isNumeric)
                {
                    message = "Não é permitido adicionar um número no lugar do nome do cliente.";
                    return false;
                }

                if (string.IsNullOrEmpty(cpf))
                {
                    _clienteRepositorio.Adicionar(cliente);
                    message = "Cliente adicionado com sucesso.";
                    return true;
                }
                else
                {
                    if (cpf != cliente.CPF)
                    {
                        _logger.LogError("Não é permitido alterar o CPF de um cliente já cadastrado. Já existe um cliente com o CPF: {0}", cpf);
                        message = $"Não é permitido alterar o CPF de um cliente já cadastrado. Já existe um cliente com o CPF: {cpf}";
                        return false;
                    }
                    _clienteRepositorio.Atualizar(cpf, cliente);
                    message = "Cliente atualizado com sucesso.";
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                message = ex.Message;
                return false;
            }
        }
    }
}
