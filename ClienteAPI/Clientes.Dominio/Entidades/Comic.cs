using System;
using System.Collections.Generic;
using System.Text;

namespace Clientes.Dominio.Entidades
{
    public class Comic
    {
        public int id { get; set; }
        public string ean { get; set; }
        public string title { get; set; }
        public string description { get; set; }

        //id, ean, title, description, entre outros.
    }
}
