using Clientes.Dominio.Entidades;
using Clientes.Dominio.Repositorios;
using Clientes.Infraestrutura.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Infraestrutura.EntityFramework.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly Func<IDbConnection> _connection;

        public ClienteRepositorio()
        {

        }

        public List<Cliente> Consultar(string cpf = "")
        {

            //using (var db = new ClientesDbContext(DbContextOptions<ClientesDbContext>options))
            //{
            //    // Read
            //    Console.WriteLine("Querying for a client");
            //    var client = db.Cliente
            //        .OrderBy(b => b.cpf)
            //        .First();
            //}

            throw new NotImplementedException();
        }

        public bool Remover(string cpf)
        {
            //using (var db = new ClientesDbContext(DbContextOptions<ClientesDbContext> options))
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
            //using (var db = new ClientesDbContext(DbContextOptions<ClientesDbContext>options))
            //{
            //    // Create
            //    Console.WriteLine("Inserting a new client");
            //    db.Add(cliente);
            //    db.SaveChanges();
            //}
        }
    }
}
