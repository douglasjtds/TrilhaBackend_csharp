using Clientes.Dominio.Entidades;
using System.Collections.Generic;

namespace Clientes.Dominio.Repositorios
{
    public interface IClienteRepositorio
    {
        List<Cliente> Consultar(string cpf = "");
        void Salvar(Cliente cliente);
        bool Remover(string cpf);
    }
}
