using Clientes.Dominio.Entidades;
using System.Collections.Generic;

namespace Clientes.Dominio.Repositorios
{
    public interface IClienteRepositorio
    {
        void Adicionar(Cliente cliente);
        Cliente Get(string cpf);
        IEnumerable<Cliente> GetAll();
        bool Atualizar(string cpf, Cliente cliente);
        void Excluir(string cpf);
    }
}
