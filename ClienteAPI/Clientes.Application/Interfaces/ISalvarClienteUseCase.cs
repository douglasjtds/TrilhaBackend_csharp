using Clientes.Dominio.Entidades;

namespace Clientes.Application.Interfaces
{
    public interface ISalvarClienteUseCase
    {
        bool Execute(Cliente cliente, out string message, string cpf);
    }
}
