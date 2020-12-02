using ServiceStack.OrmLite.Dapper;
using System.Collections.Generic;
using System.Text;
using TrilhaBackendCSharp.Dominio.Entidades;
using TrilhaBackendCSharp.Dominio.Repositorios;
using System.Linq;
using System.Data.SqlClient;

namespace TrilhaBackendCSharp.Infraestrutura.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        public const string CONNECTION_STRING = "Data Source=(local);Initial Catalog=dbClientes;Integrated Security=true";

        public ClienteRepositorio()
        {

        }

        public List<Cliente> Consultar(string cpf = "")
        {
            var consulta = new StringBuilder()
                .Append("select * from clientes")
                .Append(string.IsNullOrEmpty(cpf) ? "" : " WHERE CPF = @CPF").ToString();


            using (var connection = new SqlConnection(CONNECTION_STRING))
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

            using (var connection = new SqlConnection(CONNECTION_STRING))
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

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                numeroDeLinhasAfetasdas = connection.Execute(delete, new { CPF = new DbString() { Value = cpf, IsAnsi = true, Length = 15, IsFixedLength = true } });
            }

            return numeroDeLinhasAfetasdas > 0;
        }
    }
}
