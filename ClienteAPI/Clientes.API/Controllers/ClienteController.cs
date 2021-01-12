using Clientes.Dominio.Entidades;
using Clientes.Infraestrutura.EntityFramework.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Clientes.API.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(ILogger<ClienteController> logger, IClienteRepositorio clienteRepositorio)
        {
            _logger = logger;
            _clienteRepositorio = clienteRepositorio;
        }


        [HttpGet("{cpf}/clientes")]
        public Cliente Get([FromRoute] string cpf)
        {
            return _clienteRepositorio.Get(cpf);
        }
    }
}
