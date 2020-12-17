using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TrilhaBackendCSharp.Dominio.Entidades;
using TrilhaBackendCSharp.Dominio.Repositorios;

namespace TrilhaBackendCSharp.Infraestrutura.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly Func<IDbConnection> _connection;

        public ClienteRepositorio(Func<IDbConnection> connection)
        {
            _connection = connection;
        }

        public List<Cliente> Consultar(string cpf = "")
        {
            var consulta = new StringBuilder()
                .Append("select * from clientes")
                .Append(string.IsNullOrEmpty(cpf) ? "" : " WHERE CPF = @CPF").ToString();


            using (var connection = _connection.Invoke())
            {
                return connection.Query<Cliente>(consulta, new { CPF = new DbString() { Value = cpf, IsAnsi = true, Length = 15, IsFixedLength = true } }).ToList();
            }
        }

        public void Salvar(Cliente cliente)
        {
            string script = Consultar(cliente.CPF).Count > 0 ?

                @"UPDATE CLIENTES
                    SET NOME = @NOME,
                        IDADE = @IDADE,
                        EMAIL = @EMAIL,
                        TELEFONE = @TELEFONE,
                        ENDERECO = @ENDERECO
                    WHERE CPF = @CPF" :

                @"INSERT INTO CLIENTES 
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

            using (var connection = _connection.Invoke())
            {
                connection.Execute(script,
                        param: new
                        {
                            NOME = new DbString() { Value = cliente.Nome, IsAnsi = true },
                            IDADE = cliente.Idade,
                            EMAIL = new DbString() { Value = cliente.Email, IsAnsi = true },
                            CPF = new DbString() { Value = cliente.CPF, IsAnsi = true, Length = 15, IsFixedLength = true },
                            TELEFONE = new DbString() { Value = cliente.Telefone, IsAnsi = true },
                            ENDERECO = new DbString() { Value = cliente.Endereco, IsAnsi = true }
                        }
                    );
            }

        }

        public bool Remover(string cpf)
        {
            var delete = @"DELETE FROM CLIENTES WHERE CPF = @CPF";

            var numeroDeLinhasAfetasdas = 0;

            using (var connection = _connection.Invoke())
            {
                numeroDeLinhasAfetasdas = connection.Execute(delete, new { CPF = new DbString() { Value = cpf, IsAnsi = true, Length = 15, IsFixedLength = true } });
            }

            return numeroDeLinhasAfetasdas > 0;
        }
    }
}
