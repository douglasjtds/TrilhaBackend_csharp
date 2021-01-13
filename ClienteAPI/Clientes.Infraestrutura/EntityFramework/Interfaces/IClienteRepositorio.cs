using Clientes.Dominio.Entidades;
using System.Collections.Generic;

namespace Clientes.Infraestrutura.EntityFramework.Interfaces
{
    public interface IClienteRepositorio
    {
        void Adicionar(Cliente cliente);
        Cliente Get(string cpf);
        IEnumerable<Cliente> GetAll();
        void Atualizar(Cliente cliente);
        void Excluir(string cpf);
        void Salvar();
    }
}