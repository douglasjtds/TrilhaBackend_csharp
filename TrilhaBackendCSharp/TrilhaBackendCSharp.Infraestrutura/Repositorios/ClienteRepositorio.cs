using ServiceStack.OrmLite.Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using TrilhaBackendCSharp.Dominio.Entidades;
using TrilhaBackendCSharp.Dominio.Repositorios;
using TrilhaBackendCSharp.Infraestrutura.DatabaseInMemory;

namespace TrilhaBackendCSharp.Infraestrutura.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly InMemoryDatabase _database;
        public ClienteRepositorio()
        {
            _database = new InMemoryDatabase();
        }

        public List<Cliente> Consultar(string cpf = "")
        {
            const string consulta = "SELECT * FROM CLIENTES";
            using (var connection = _database.Connection)
            {
                //return connection.Query<Cliente>(consulta).ToList();
            }
            throw new NotImplementedException();
        }

        public void Salvar(Cliente cliente)
        {
            //1 - Missão 1, fazer script de Insert e Update de acordo com a situação.
            if (Consultar(cliente.CPF).Count > 0)
            {
                // update
            }
            else
            {
                //insert
            }
            throw new NotImplementedException();
        }

        public bool Remover(string cpf)
        {
            //2 - Missão 2, fazer script de Delete.
            throw new NotImplementedException();
        }
    }
}
