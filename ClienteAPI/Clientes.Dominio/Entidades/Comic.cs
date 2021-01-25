using System;
using System.Collections.Generic;
using System.Text;

namespace Clientes.Dominio.Entidades
{
    public class Comic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Ean { get; set; }
        public string Description { get; set; }
    }
}
