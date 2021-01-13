using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace Clientes.Application.UseCases
{
    public class SalvarClienteUseCase : ISalvarClienteUseCase
    {
        private readonly ILogger<SalvarClienteUseCase> _logger;
        private readonly IConfiguration _configuration;

        public SalvarClienteUseCase(ILogger<SalvarClienteUseCase> logger, IConfiguration configuration)
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
