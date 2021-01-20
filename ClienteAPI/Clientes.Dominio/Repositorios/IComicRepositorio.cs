using Clientes.Dominio.Entidades;
using System.Collections.Generic;

namespace Clientes.Dominio.Repositorios
{
    public interface IComicRepositorio
    {
        IList<Comic> Get(string hero);

        bool Salvar(IList<Comic> comics);
    }
}
