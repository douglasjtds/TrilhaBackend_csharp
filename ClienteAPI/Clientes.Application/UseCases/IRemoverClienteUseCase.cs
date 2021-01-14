using System;
using System.Collections.Generic;
using System.Text;

namespace Clientes.Application.UseCases
{
    public interface IRemoverClienteUseCase
    {
        bool Execute(string cpf);
    }
}
