using Clientes.Dominio.Entidades;
using Clientes.Dominio.Repositorios;
using Clientes.Infraestrutura.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Clientes.Infraestrutura.Repositorio
{
    public class ComicRepositorio : IComicRepositorio
    {
        private readonly ComicDbContext _clientesDbContext;
        private readonly ILogger<ComicRepositorio> _logger;
        private readonly IConfiguration _config;

        public ComicRepositorio(ComicDbContext clientesDbContext, ILogger<ComicRepositorio> logger, IConfiguration config)
        {
            _logger = logger;
            _clientesDbContext = clientesDbContext;
            _config = config;
        }
        public IList<Comic> Get(string hero)
        {
            //using (var client = new HttpClient())
            //{
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    string ts = DateTime.Now.Ticks.ToString();
            //    string publicKey = _config.GetSection("MarvelComicsAPI:PublicKey").Value;
            //    string hash = GerarHash(ts, publicKey,
            //        _config.GetSection("MarvelComicsAPI:PrivateKey").Value);

            //    HttpResponseMessage responseMessage = client.GetAsync(_config.GetSection("MarvelComicsAPI:BaseURL").Value
            //        + $"characters?ts={ts}&apikey={publicKey}&hash={hash}&" +
            //        $"name={Uri.EscapeUriString(hero)}").Result;

            //    responseMessage.EnsureSuccessStatusCode();
            //    string content = responseMessage.Content.ReadAsStringAsync().Result;

            //    dynamic result = JsonConvert.DeserializeObject(content);

            //    var personagem = new Personagem
            //    {
            //        Nome = result.data.results[0].name,
            //        Descricao = result.data.results[0].description,
            //        UrlImagem = result.data.results[0].thumbnail.path + "." + result.data.results[0].thumbnail.extension,
            //        UrlWiki = result.data.results[0].urls[1].url
            //    };

            //}
            return new NotImplementedException();
        }

        public bool Salvar(IList<Comic> comics)
        {
            try
            {
                foreach (var comic in comics)
                {
                    _clientesDbContext.Comics.Add(comic);
                    _clientesDbContext.SaveChanges();
                    _logger.LogInformation("Quadrinho salvo com sucesso.");
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
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
