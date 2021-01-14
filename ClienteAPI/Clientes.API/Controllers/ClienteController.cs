using Clientes.Dominio.Entidades;
using Clientes.Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Clientes.API.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("{cpf}")]
        public IActionResult Get([FromRoute] string cpf)
        {
            try
            {
                return Ok(_clienteRepositorio.Get(cpf));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_clienteRepositorio.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post(Cliente cliente)
        {
            try
            {
                _clienteRepositorio.Adicionar(cliente);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("{cpf}")]
        public IActionResult Put([FromRoute] string cpf, [FromBody] Cliente cliente)
        {
            try
            {
                _clienteRepositorio.Atualizar(cpf, cliente);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("{cpf}")]
        public IActionResult Delete([FromRoute] string cpf)
        {
            try
            {
                _clienteRepositorio.Excluir(cpf);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
