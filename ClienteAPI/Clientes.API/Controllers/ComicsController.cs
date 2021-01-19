using Clientes.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

namespace Clientes.API.Controllers
{
    [Route("/v1/public/comics")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        private readonly ILogger<ComicsController> _logger;
        public ComicsController(ILogger<ComicsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get([FromServices] IConfiguration config, string hero)
        {
            Personagem personagem;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string ts = DateTime.Now.Ticks.ToString();
                string publicKey = config.GetSection("MarvelComicsAPI:PublicKey").Value;
                string hash = GerarHash(ts, publicKey,
                    config.GetSection("MarvelComicsAPI:PrivateKey").Value);

                HttpResponseMessage responseMessage = client.GetAsync(config.GetSection("MarvelComicsAPI:BaseURL").Value
                    + $"characters?ts={ts}&apikey={publicKey}&hash={hash}&" +
                    $"name={Uri.EscapeUriString(hero)}").Result;

                responseMessage.EnsureSuccessStatusCode();
                string content = responseMessage.Content.ReadAsStringAsync().Result;

                dynamic result = JsonConvert.DeserializeObject(content);

                personagem = new Personagem
                {
                    Nome = result.data.results[0].name,
                    Descricao = result.data.results[0].description,
                    UrlImagem = result.data.results[0].thumbnail.path + "." + result.data.results[0].thumbnail.extension,
                    UrlWiki = result.data.results[0].urls[1].url
                };

                return Ok(personagem);
            }
        }

        private string GerarHash(string ts, string publicKey, string privateKey)
        {
            byte[] bytes =
                Encoding.UTF8.GetBytes(ts + privateKey + publicKey);
            var gerador = MD5.Create();
            byte[] bytesHash = gerador.ComputeHash(bytes);
            return BitConverter.ToString(bytesHash)
                .ToLower().Replace("-", String.Empty);
        }
    }
}
