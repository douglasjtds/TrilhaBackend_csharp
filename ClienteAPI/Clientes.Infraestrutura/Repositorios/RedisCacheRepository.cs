using Clientes.Infraestrutura.Configurations;
using Clientes.Infraestrutura.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace Clientes.Infraestrutura.Repositorios
{
    public class RedisCacheRepository<TModel> : ICacheRepository<TModel>
    {
        private readonly ConnectionMultiplexer _connection;
        private readonly IOptions<Config> _configuration;
        public RedisCacheRepository(ConnectionMultiplexer conn, IOptions<Config> config)
        {
            _connection = conn;
            _configuration = config;
        }


        public async Task<TModel> PegarCacheAsync(string? chave)
        {
            try
            {
                if (_configuration.Value.Disabled)
                    return await Task.FromResult(default(TModel));

                chave = SetarChaveForte(chave);
                var redis = _connection.GetDatabase();
                var json = await redis.StringGetAsync(chave);
                if (json.Length() == 0) return await Task.FromResult(default(TModel));
                return JsonConvert.DeserializeObject<TModel>(json);
            }
            catch
            {
                return await Task.FromResult(default(TModel));
            }
        }
        public async Task GravarCacheAsync(string chave, TModel entity, TimeSpan cacheDuration)
        {
            try
            {
                if (_configuration.Value.Disabled)
                    await Task.Yield();

                chave = SetarChaveForte(chave);
                var redis = _connection.GetDatabase();
                var json = JsonConvert.SerializeObject(entity);
                await redis.StringSetAsync(chave, json, cacheDuration);
            }
            catch
            {
                await Task.Yield();
            }
        }

        public async Task RemoverCacheAsync(string chave)
        {
            try
            {
                if (_configuration.Value.Disabled)
                    await Task.Yield();

                chave = SetarChaveForte(chave);
                var redis = _connection.GetDatabase();
                await redis.KeyDeleteAsync(chave);
            }
            catch
            {
                await Task.Yield();
            }
        }

        private static string SetarChaveForte(string chave)
        {
            chave = $"{typeof(TModel).FullName?.Replace(".", "").ToLower()}{chave}";
            return chave;
        }
    }
}
