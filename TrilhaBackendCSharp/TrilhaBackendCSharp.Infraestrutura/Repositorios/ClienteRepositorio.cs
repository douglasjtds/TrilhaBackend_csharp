using System;
using System.Collections.Generic;
using System.Text;
using TrilhaBackendCSharp.Dominio.Entidades;
using TrilhaBackendCSharp.Dominio.Repositorios;

namespace TrilhaBackendCSharp.Infraestrutura.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        public List<Cliente> Consultar(string cpf = "")
        {
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
