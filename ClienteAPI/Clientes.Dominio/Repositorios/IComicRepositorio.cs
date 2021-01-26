using Clientes.Dominio.Entidades;

namespace Clientes.Dominio.Repositorios
{
    public interface IComicRepositorio
    {
        bool Salvar(Comic comic);
    }
}
