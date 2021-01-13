using Clientes.Dominio.Entidades;
using Clientes.Dominio.Repositorios;
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

        [HttpPost("/v1/create/cliente")]
        public ActionResult Post(Cliente cliente)
        {
            try
            {
                _clienteRepositorio.Adicionar(cliente);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        [HttpPut("{cpf}/v1/update/cliente")]
        public ActionResult Put(Cliente cliente)
        {
            try
            {
                _clienteRepositorio.Atualizar(cliente);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        [HttpDelete("{cpf}/v1/delete/cliente")]
        public ActionResult Delete([FromRoute] string cpf)
        {
            try
            {
                _clienteRepositorio.Excluir(cpf);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }
    }
}
