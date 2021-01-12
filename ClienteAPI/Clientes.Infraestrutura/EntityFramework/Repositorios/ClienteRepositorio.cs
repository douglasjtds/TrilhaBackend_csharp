using Clientes.Dominio.Entidades;
using Clientes.Infraestrutura.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Clientes.Infraestrutura.EntityFramework.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        //private readonly Func<IDbConnection> _connection;
        //private readonly DbContextOptions<ClientesDbContext> _options;
        private readonly ClientesDbContext _clientesDbContext;

        //public ClienteRepositorio(DbContextOptions<ClientesDbContext> options)
        //{
        //    _options = options;
        //}

        public ClienteRepositorio(ClientesDbContext clientesDbContext)
        {
            _clientesDbContext = clientesDbContext;
        }

        public Cliente Get(string cpf)
        {
            return _clientesDbContext.Clientes.Where(p => p.CPF == cpf).FirstOrDefault();
        }

        public List<Cliente> Consultar(string cpf = "")
        {
            //using (var db = new ClientesDbContext(_options))
            //{
            //    //// Read
            //    //Console.WriteLine("Querying for a client");
            //    //var client = db.
            //    //    .OrderBy(b => b.cpf)
            //    //    .First();
            //}
            throw new NotImplementedException();
        }

        public bool Remover(string cpf)
        {
            //using (var db = new ClientesDbContext(_options))
            //{
            //    // Delete
            //    Console.WriteLine("Delete the client");
            //    db.Remove(cpf);
            //    db.SaveChanges();
            //}
            throw new NotImplementedException();
        }

        public void Salvar(Cliente cliente)
        {
            //using (var db = new ClientesDbContext(_options))
            //{
            //    // Create
            //    Console.WriteLine("Inserting a new client");
            //    db.Add(cliente);
            //    db.SaveChanges();
            //}
        }
    }
}
