using Clientes.Dominio.Entidades;
using Clientes.Dominio.Repositorios;
using Clientes.Infraestrutura.Configurations;
using Clientes.Infraestrutura.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clientes.Infraestrutura.Decorator
{
    public class ClienteRepositorioCache : IClienteRepositorio
    {
        private readonly ICacheRepository<Cliente> _cacheRepository;
        private readonly ICacheRepository<IList<Cliente>> _cacheRepositoryList;
        private readonly CacheDuration _cacheDuration;
        private readonly IClienteRepositorio _decorate;

        public ClienteRepositorioCache(ICacheRepository<Cliente> cacheRepository, 
            IOptions<CacheDuration> cacheDuration, IClienteRepositorio decorate, 
            ICacheRepository<IList<Cliente>> cacheRepositoryList)
        {
            _cacheRepository = cacheRepository;
            _cacheDuration = cacheDuration.Value;
            _decorate = decorate;
            _cacheRepositoryList = cacheRepositoryList;
        }

        public void Adicionar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public bool Atualizar(string cpf, Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public bool Excluir(string cpf)
        {
            throw new NotImplementedException();
        }

        public Cliente Get(string cpf)
        {
            var cliente = _cacheRepository.PegarCacheAsync(cpf).Result;
            if (!(cliente is null))
                return cliente;

            cliente = _decorate.Get(cpf);
            _cacheRepository.GravarCacheAsync(cpf, cliente, _cacheDuration.Clientes);

            return cliente;
        }

        public IList<Cliente> GetAll()
        {
            var clientes = _cacheRepositoryList.PegarCacheAsync(null).Result;

            if (!(clientes is null))
                return clientes;

            clientes = _decorate.GetAll();
            foreach (var cliente in clientes)
            {
                _cacheRepositoryList.GravarCacheAsync(cliente.CPF, clientes, _cacheDuration.Clientes);
            }
            return clientes;
        }
    }
}
