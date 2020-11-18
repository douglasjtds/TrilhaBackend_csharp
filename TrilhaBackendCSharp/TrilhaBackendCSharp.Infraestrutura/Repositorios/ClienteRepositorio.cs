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
                var update = @"UPDATE CLIENTES
                                SET NOME = @NOME,
                                        IDADE = @IDADE,
                                        EMAIL = @EMAIL,
                                        TELEFONE = @TELEFONE,
                                        ENDERECO = @ENDERECO
                                WHERE CPF = @CPF";

                using (var connection = _database.Connection)
                {
                    connection.Query<Cliente>(update,
                            new
                            {
                                NOME = new DbString() { Value = cliente.Nome, IsAnsi = true },
                                IDADE = cliente.Idade,
                                EMAIL = new DbString() { Value = cliente.Email, IsAnsi = true },
                                CPF = new DbString() { Value = cliente.CPF, IsAnsi = true, Length = 15, IsFixedLength = true },
                                TELEFONE = new DbString() { Value = cliente.Telefone, IsAnsi = true },
                                ENDERECO = new DbString() { Value = cliente.Endereco, IsAnsi = true }
                            }
                        ).ToList();
                }

            }
            else
            {
                //insert
                var insert = @"INSERT INTO CLIENTES 
                                    (NOME, 
                                    IDADE, 
                                    CPF, 
                                    EMAIL, 
                                    TELEFONE, 
                                    ENDERECO) 
                                VALUES(@NOME, 
                                    @IDADE, 
                                    @CPF, 
                                    @EMAIL, 
                                    @TELEFONE, 
                                    @ENDERECO)";

                using (var connection = _database.Connection)
                {
                    connection.Query<Cliente>(insert,
                            new
                            {
                                NOME = new DbString() { Value = cliente.Nome, IsAnsi = true },
                                IDADE = cliente.Idade,
                                EMAIL = new DbString() { Value = cliente.Email, IsAnsi = true },
                                CPF = new DbString() { Value = cliente.CPF, IsAnsi = true, Length = 15, IsFixedLength = true },
                                TELEFONE = new DbString() { Value = cliente.Telefone, IsAnsi = true },
                                ENDERECO = new DbString() { Value = cliente.Endereco, IsAnsi = true }
                            }
                        ).ToList();
                }
            }
        }

        public bool Remover(string cpf)
        {
            //2 - Missão 2, fazer script de Delete.
            var delete = @"DELETE FROM CLIENTES WHERE CPF = @CPF";

            var numeroDeLinhasAfetasdas = 0;

            using (var connection = _database.Connection)
            {
                numeroDeLinhasAfetasdas = connection.Execute(delete, new { CPF = new DbString() { Value = cpf, IsAnsi = true, Length = 15, IsFixedLength = true } });
            }

            if (numeroDeLinhasAfetasdas > 0)
                return true;
            else
                return false;
        }
    }
}
