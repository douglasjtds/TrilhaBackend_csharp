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

        /// <summary>
        /// Obtém um cliente específico à partir do CPF.
        /// </summary>
        /// <param name="cpf">CPF do cliente que deseja obter.</param>
        /// <response code="200">Cliente obtido com sucesso.</response>
        /// <response code="404">Não foi encontrado um cliente com o CPF especificado.</response>
        /// <response code="500">Ocorreu um erro ao obter o cliente.</response>
        [HttpGet("{cpf}")]
        [ProducesResponseType(typeof(Cliente), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Get([FromRoute] string cpf)
        {
            try
            {
                var cliente = _clienteRepositorio.Get(cpf);

                if (cliente == null)
                    return NotFound(new { mensagem = "Cliente não encontrado." });

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Obtém todos os clientes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Cliente>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
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

        /// <summary>
        /// Adiciona um novo cliente.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
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

        /// <summary>
        /// Atualiza os dados de um cliente existente.
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPut("{cpf}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
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


        /// <summary>
        /// Exclui um cliente da base de dados.
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [HttpDelete("{cpf}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
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
