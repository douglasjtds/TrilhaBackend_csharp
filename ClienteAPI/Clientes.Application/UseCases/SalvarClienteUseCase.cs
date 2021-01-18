using Clientes.Application.Interfaces;
using Clientes.Dominio.Entidades;
using Clientes.Dominio.Exceptions;
using Clientes.Dominio.Repositorios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Clientes.Application.UseCases
{
    public class SalvarClienteUseCase : ISalvarClienteUseCase
    {
        private readonly ILogger<SalvarClienteUseCase> _logger;
        private readonly IClienteRepositorio _clienteRepositorio;

        public SalvarClienteUseCase(ILogger<SalvarClienteUseCase> logger, IClienteRepositorio clienteRepositorio)
        {
            _logger = logger;
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
                    //não permitir CPF com letras
                    if (IsDigitsOnly(cliente.CPF))
                    {
                        _clienteRepositorio.Adicionar(cliente);
                        message = "Cliente adicionado com sucesso.";
                        return true;
                    }
                    message = "Campo CPF deve conter apenas dígitos.";
                    throw new InvalidCPFException(message);
                }
                else
                {
                    if (cpf != cliente.CPF)
                    {
                        _logger.LogError("Não é permitido alterar o CPF de um cliente já cadastrado. Já existe um cliente com o CPF: {0}", cpf);
                        message = $"Não é permitido alterar o CPF de um cliente já cadastrado. Já existe um cliente com o CPF: {cpf}";
                        throw new UpdateCPFException(message);
                    }
                    bool clienteAtualizado = _clienteRepositorio.Atualizar(cpf, cliente);
                    message = "Cliente atualizado com sucesso.";
                    return clienteAtualizado;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                message = ex.Message;
                return false;
            }
        }


        public bool IsDigitsOnly(string str)
        {
            return str.All(c => c >= '0' && c <= '9');
        }
    }
}
