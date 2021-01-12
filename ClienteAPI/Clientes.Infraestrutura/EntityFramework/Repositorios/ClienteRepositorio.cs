using Clientes.Dominio.Entidades;
using Clientes.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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

            //using (var db = new BloggingContext())
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
            //using (var db = new BloggingContext())
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
            //using (var db = new BloggingContext())
            //{
            //    // Create
            //    Console.WriteLine("Inserting a new client");
            //    db.Add(cliente);
            //    db.SaveChanges();
            //}
        }
    }
}
