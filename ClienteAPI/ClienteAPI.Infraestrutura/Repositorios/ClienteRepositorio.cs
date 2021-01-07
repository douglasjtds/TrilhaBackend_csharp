using ClienteAPI.Dominio.Entidades;
using ClienteAPI.Dominio.Repositorios;
using System;
using System.Collections.Generic;

namespace ClienteAPI.Infraestrutura
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        public ClienteRepositorio()
        {

        }

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
