using Clientes.Dominio.Entidades;
using System.Collections.Generic;

namespace Clientes.Infraestrutura.EntityFramework.Interfaces
{
    public interface IClienteRepositorio
    {
        Cliente Get(string cpf);
        List<Cliente> Consultar(string cpf = "");
        void Salvar(Cliente cliente);
        bool Remover(string cpf);
    }
}