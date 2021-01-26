﻿using Clientes.Application.Interfaces;
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

        public IList<Comic> Execute(string hero)
        {
            try
            {
                var personagem = BuscarPersonagem(hero);
                var comics = BuscarComics(personagem.Id);

                bool saved = false;
                if (comics != null)
                    saved = _comicRepositorio.Salvar(comics);

                if (saved)
                    return comics;
                else
                    _logger.LogError("Erro ao salvar quadrinho");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }


        private Personagem BuscarPersonagem(string hero)
        {
            Personagem personagem;

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

                personagem = new Personagem
                {
                    Id = result.data.results[0].id,
                    Nome = result.data.results[0].name,
                    Descricao = result.data.results[0].description,
                    UrlImagem = result.data.results[0].thumbnail.path + "." + result.data.results[0].thumbnail.extension,
                    UrlWiki = result.data.results[0].urls[1].url,
                    NumberOfComicsAvailable = result.data.results[0].comics.available
                };
            }
            return personagem;
        }

        private IList<Comic> BuscarComics(int id)
        {
            IList<Comic> comics = new List<Comic>();
            Comic comic;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string ts = DateTime.Now.Ticks.ToString();
                string publicKey = _config.GetSection("MarvelComicsAPI:PublicKey").Value;
                string hash = GerarHash(ts, publicKey,
                    _config.GetSection("MarvelComicsAPI:PrivateKey").Value);
                HttpResponseMessage responseMessage = client.GetAsync(_config.GetSection("MarvelComicsAPI:BaseURL").Value
                        + $"characters" + $"/{id}/comics" +
                        $"?ts={ts}&apikey={publicKey}&hash={hash}&").Result;

                responseMessage.EnsureSuccessStatusCode();
                string content = responseMessage.Content.ReadAsStringAsync().Result;

                dynamic result = JsonConvert.DeserializeObject(content);

                int indice = 0;
                foreach (var item in result.data.results)
                {
                    comic = new Comic()
                    {
                        Id = result.data.results[indice].id,
                        Title = result.data.results[indice].title,
                        Description = result.data.results[indice].description,
                        Ean = result.data.results[indice].ean
                    };
                    comics.Add(comic);
                    indice++;
                }
            }
            return comics;
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
