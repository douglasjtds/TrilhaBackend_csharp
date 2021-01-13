using Clientes.Dominio.Entidades;
using Clientes.Infraestrutura.EntityFramework.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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


        [HttpGet("{cpf}/v1/clientes")]
        public Cliente Get([FromRoute] string cpf)
        {
            try
            {
                return _clienteRepositorio.Get(cpf);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        [HttpGet("/v1/clientes")]
        public IEnumerable<Cliente> GetAll()
        {
            try
            {
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
