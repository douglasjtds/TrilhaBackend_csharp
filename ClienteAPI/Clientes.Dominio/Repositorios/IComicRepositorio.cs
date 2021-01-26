using Clientes.Dominio.Entidades;
using System.Collections.Generic;

namespace Clientes.Dominio.Repositorios
{
    public interface IComicRepositorio
    {
        bool Salvar(IList<Comic> comics);
    }
}
