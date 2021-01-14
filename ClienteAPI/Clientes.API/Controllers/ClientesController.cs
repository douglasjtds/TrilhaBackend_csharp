using Clientes.Application.Interfaces;
using Clientes.Dominio.Entidades;
using Clientes.Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;

namespace Clientes.API.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;

        //private readonly IClienteRepositorio _clienteRepositorio;

        private readonly IBuscarClienteUseCase _buscarClienteUseCase;
        private readonly ISalvarClienteUseCase _salvarClienteUseCase;
        private readonly IRemoverClienteUseCase _removerClienteUseCase;


        public ClientesController(ILogger<ClientesController> logger, IBuscarClienteUseCase buscarClienteUseCase, ISalvarClienteUseCase salvarClienteUseCase, IRemoverClienteUseCase removerClienteUseCase, IClienteRepositorio clienteRepositorio)
        {
            _logger = logger;

            //_clienteRepositorio = clienteRepositorio;

            _buscarClienteUseCase = buscarClienteUseCase;
            _salvarClienteUseCase = salvarClienteUseCase;
            _removerClienteUseCase = removerClienteUseCase;
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
                var cliente = _buscarClienteUseCase.Execute(cpf);

                if (cliente == null)
                    return NotFound(new { mensagem = "Não foi encontrado um cliente com esse CPF na base." });

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
        /// /// <response code="200">Clientes obtidos com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao obter os clientes.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Cliente>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_buscarClienteUseCase.Execute(""));
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
        /// <param name="cliente">json com as informações do novo cliente</param>
        /// <response code="200">Cliente adicionado com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao adicionar o cliente.</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Post(Cliente cliente)
        {
            try
            {
                _salvarClienteUseCase.Execute(cliente, "");
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
        /// <param name="cpf">CPF do cliente que deseja atualizar.</param>
        /// <param name="cliente">json com as informações do cliente que deseja atualizar</param>
        /// <response code="200">Cliente atualizado com sucesso.</response>
        /// <response code="404">Não foi encontrado um cliente com o CPF especificado.</response>
        /// <response code="500">Ocorreu um erro ao atualizar o cliente.</response>
        [HttpPut("{cpf}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Put([FromRoute] string cpf, [FromBody] Cliente cliente)
        {
            try
            {
                _salvarClienteUseCase.Execute(cliente, cpf);
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
        /// <param name="cpf">CPF do cliente que deseja excluir.</param>
        /// <response code="200">Cliente excluído com sucesso.</response>
        /// <response code="404">Não foi encontrado um cliente com o CPF especificado.</response>
        /// <response code="500">Ocorreu um erro ao excluír o cliente.</response>
        [HttpDelete("{cpf}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Delete([FromRoute] string cpf, out string message)
        {
            try
            {
                var clienteRemovido = _removerClienteUseCase.Execute(cpf, out message);

                if (clienteRemovido == false)
                    return NotFound(new { mensagem = "Não foi encontrado um cliente com esse CPF na base." });

                return Ok(clienteRemovido);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                message = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
