using System;

namespace Clientes.Dominio.Exceptions
{
    public class InvalidCPFException : Exception
    {
        public InvalidCPFException(string message) : base(message)
        {

        }
    }
}
