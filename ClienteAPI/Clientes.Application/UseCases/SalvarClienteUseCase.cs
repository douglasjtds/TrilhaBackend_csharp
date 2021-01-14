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

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
