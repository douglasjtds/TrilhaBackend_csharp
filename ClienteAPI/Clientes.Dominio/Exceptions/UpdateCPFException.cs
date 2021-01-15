using System;
using System.Collections.Generic;
using System.Text;

namespace Clientes.Dominio.Exceptions
{
    public class UpdateCPFException : Exception
    {
        public UpdateCPFException(string message) : base(message)
        {

        }
    }
}
