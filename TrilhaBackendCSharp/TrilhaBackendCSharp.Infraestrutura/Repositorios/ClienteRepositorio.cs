using ServiceStack.OrmLite.Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using TrilhaBackendCSharp.Dominio.Entidades;
using TrilhaBackendCSharp.Dominio.Repositorios;
using TrilhaBackendCSharp.Infraestrutura.DatabaseInMemory;
using System.Linq;

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
            var consulta = new StringBuilder()
                .Append("select * from clientes")
                .Append(string.IsNullOrEmpty(cpf) ? "" : " WHERE CPF = @CPF").ToString();

            using (var connection = _database.Connection)
            {
                return connection.Query<Cliente>(consulta, new { CPF = new DbString() { Value = cpf, IsAnsi = true, Length = 15, IsFixedLength = true } }).ToList();
            }
        }

        public void Salvar(Cliente cliente)
        {
            //1 - Missão 1, fazer script de Insert e Update de acordo com a situação.
            if (Consultar(cliente.CPF).Count > 0)
            {
                // update
                var update = $"UPDATE CLIENTES " +
                                $"SET NOME = '{cliente.Nome}', IDADE = {cliente.Idade}, EMAIL = {cliente.CPF}, TELEFONE = {cliente.Telefone}, ENDERECO = {cliente.Endereco}" +
                                $"WHERE CPF = @CPF";
            }
            else
            {
                //insert
                var insert = $"INSERT INTO CLIENTES (NOME, IDADE, CPF, EMAIL, TELEFONE, ENDERECO) " +
                                $"VALUES({cliente.Nome}, {cliente.Idade}, {cliente.CPF}, {cliente.Email}, {cliente.Telefone}, {cliente.Endereco});";
            }
        }

        public bool Remover(string cpf)
        {
            //2 - Missão 2, fazer script de Delete.
            throw new NotImplementedException();
        }
    }
}
