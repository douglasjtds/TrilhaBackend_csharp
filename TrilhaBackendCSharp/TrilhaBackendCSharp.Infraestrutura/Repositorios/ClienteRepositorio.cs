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
        public ClienteRepositorio()
        {

        }

        public List<Cliente> Consultar(string cpf = "")
        {
            throw new NotImplementedException();
            //var db = new InMemoryDatabase();
            //var Teste = @"SELECT * FROM CLIENTES;";

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
