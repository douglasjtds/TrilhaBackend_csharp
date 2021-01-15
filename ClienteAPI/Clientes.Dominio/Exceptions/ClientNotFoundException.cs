using System;
using System.Collections.Generic;
using System.Text;

namespace Clientes.Dominio.Exceptions
{
    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException(string message) : base(message)
        {

        }
    }
}
