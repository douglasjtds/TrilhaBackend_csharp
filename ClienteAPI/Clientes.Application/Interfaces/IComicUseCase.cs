using Clientes.Dominio.Entidades;
using System.Collections.Generic;

namespace Clientes.Application.Interfaces
{
    public interface IComicUseCase
    {
        IList<Comic> Execute(string hero);
    }
}
