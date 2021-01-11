using Clientes.Dominio.Entidades;
using Clientes.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Data;

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
            //var consulta = new StringBuilder()
            //    .Append("select * from clientes")
            //    .Append(string.IsNullOrEmpty(cpf) ? "" : " WHERE CPF = @CPF").ToString();


            //using (var connection = _connection.Invoke())
            //{
            //    return connection.Query<Cliente>(consulta, new { CPF = new DbString() { Value = cpf, IsAnsi = true, Length = 15, IsFixedLength = true } }).ToList();
            //}
            throw new NotImplementedException();
        }

        public bool Remover(string cpf)
        {
            throw new NotImplementedException();
        }

        public void Salvar(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
