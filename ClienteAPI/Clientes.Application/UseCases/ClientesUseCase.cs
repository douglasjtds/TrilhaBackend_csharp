using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace Clientes.Application.UseCases
{
    public class ClientesUseCase : IClientesUseCase
    {
        private readonly ILogger<ClientesUseCase> _logger;
        private readonly IConfiguration _configuration;

        public ClientesUseCase(ILogger<ClientesUseCase> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
