using System;

namespace Clientes.Dominio.Exceptions
{
    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException(string message) : base(message)
        {

        }
    }
}
