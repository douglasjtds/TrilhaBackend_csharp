using Clientes.Dominio.Entidades;

namespace Clientes.Application.Interfaces
{
    public interface IComicUseCase
    {
        Comic Execute(string hero);
    }
}
