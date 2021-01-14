using Clientes.Application.Interfaces;
using Clientes.Dominio.Repositorios;
using Microsoft.Extensions.Logging;
using System;

namespace Clientes.Application.UseCases
{
    public class RemoverClienteUseCase : IRemoverClienteUseCase
    {
        private readonly ILogger<RemoverClienteUseCase> _logger;
        private readonly IClienteRepositorio _clienteRepositorio;
        public RemoverClienteUseCase(ILogger<RemoverClienteUseCase> logger, IClienteRepositorio clienteRepositorio)
        {
            _logger = logger;
            _clienteRepositorio = clienteRepositorio;
        }

        public bool Execute(string cpf, out string message)
        {
            try
            {
                var clienteParaExcluir = _clienteRepositorio.Excluir(cpf);

                if (clienteParaExcluir == false)
                {
                    message = "Não foi encontrado um cliente com esse CPF na base.";
                    return false;
                }

                message = "Cliente removido com sucesso.";
                return true;
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
