using Clientes.Dominio.Entidades;

namespace Clientes.Application.Interfaces
{
    public interface ISalvarClienteUseCase
    {
        void Execute(Cliente cliente, string cpf);
    }
}
