using Clientes.Dominio.Entidades;
using System.Collections.Generic;

namespace Clientes.Dominio.Repositorios
{
    public interface IClienteRepositorio
    {
        void Adicionar(Cliente cliente);
        Cliente Get(string cpf);
        IList<Cliente> GetAll();
        bool Atualizar(string cpf, Cliente cliente);
        bool Excluir(string cpf);
    }
}
