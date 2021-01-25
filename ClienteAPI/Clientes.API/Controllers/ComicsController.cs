using Clientes.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Clientes.API.Controllers
{
    [Route("/v1/public/comics")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        private readonly ILogger<ComicsController> _logger;
        private readonly IComicUseCase _comicUseCase;
        public ComicsController(ILogger<ComicsController> logger, IComicUseCase comicUseCase)
        {
            _logger = logger;
            _comicUseCase = comicUseCase;
        }

        [HttpGet]
        public IActionResult Get(string hero)
        {
            try
            {
                //var personagem = _comicUseCase.Execute(hero);
                var comics = _comicUseCase.Execute(hero);

                return Ok(comics);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return NotFound(ex.Message + " - Herói não encontrado.");
            }
        }
    }
}
