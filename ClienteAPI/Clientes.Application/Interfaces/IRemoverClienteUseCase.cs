namespace Clientes.Application.Interfaces
{
    public interface IRemoverClienteUseCase
    {
        bool Execute(string cpf, out string message);
    }
}
