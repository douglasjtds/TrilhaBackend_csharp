using ClienteAPI.Dominio.Entidades;
using System.Collections.Generic;

namespace ClienteAPI.Dominio.Repositorios
{
    public interface IClienteRepositorio
    {
        List<Cliente> Consultar(string cpf = "");
        void Salvar(Cliente cliente);
        bool Remover(string cpf);
    }
}
