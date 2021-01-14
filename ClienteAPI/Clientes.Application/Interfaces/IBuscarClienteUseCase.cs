using Clientes.Dominio.Entidades;
using System.Collections.Generic;

namespace Clientes.Application.Interfaces
{
    public interface IBuscarClienteUseCase
    {
        IList<Cliente> Execute(string cpf);
    }
}
