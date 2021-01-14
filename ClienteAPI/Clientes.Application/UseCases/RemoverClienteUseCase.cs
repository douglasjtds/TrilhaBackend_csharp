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

        public bool Execute(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}
