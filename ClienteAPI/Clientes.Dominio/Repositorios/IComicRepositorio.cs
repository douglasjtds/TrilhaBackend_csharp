using Clientes.Dominio.Entidades;
using System.Collections.Generic;

namespace Clientes.Dominio.Repositorios
{
    public interface IComicRepositorio
    {
        object Get(string hero);

        bool Salvar(Comic comic);
    }
}
