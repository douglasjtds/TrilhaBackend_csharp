using Clientes.Application.Interfaces;
using Clientes.Dominio.Entidades;
using Clientes.Dominio.Repositorios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

namespace Clientes.Application.UseCases
{
    public class ComicUseCase : IComicUseCase
    {
        private readonly ILogger<ComicUseCase> _logger;
        private readonly IConfiguration _config;
        private readonly IComicRepositorio _comicRepositorio;

        public ComicUseCase(ILogger<ComicUseCase> logger, IComicRepositorio comicRepositorio, IConfiguration config)
        {
            _logger = logger;
            _comicRepositorio = comicRepositorio;
            _config = config;
        }

        public void Execute(string hero)
        {
            try
            {
                var personagem = BuscarPersonagem(hero);
                var comics = _comicRepositorio.Get(hero);
                //_comicRepositorio.Salvar(comics);

                //return comics;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                //return null;
            }
        }


        private IList<Personagem> BuscarPersonagem(string hero)
        {
            Personagem personagem;
            var personagens = new List<Personagem>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string ts = DateTime.Now.Ticks.ToString();
                string publicKey = _config.GetSection("MarvelComicsAPI:PublicKey").Value;
                string hash = GerarHash(ts, publicKey,
                    _config.GetSection("MarvelComicsAPI:PrivateKey").Value);
                HttpResponseMessage responseMessage = client.GetAsync(_config.GetSection("MarvelComicsAPI:BaseURL").Value
                        + $"characters?ts={ts}&apikey={publicKey}&hash={hash}&" +
                        $"name={Uri.EscapeUriString(hero)}").Result;

                responseMessage.EnsureSuccessStatusCode();
                string content = responseMessage.Content.ReadAsStringAsync().Result;

                dynamic result = JsonConvert.DeserializeObject(content);

                foreach (var item in result.data.results)
                {
                    personagem = new Personagem
                    {
                        Nome = result.data.results[0].name,
                        Descricao = result.data.results[0].description,
                        UrlImagem = result.data.results[0].thumbnail.path + "." + result.data.results[0].thumbnail.extension,
                        UrlWiki = result.data.results[0].urls[1].url
                    };
                    personagens.Add(personagem);
                }               
            }
            return personagens;
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
