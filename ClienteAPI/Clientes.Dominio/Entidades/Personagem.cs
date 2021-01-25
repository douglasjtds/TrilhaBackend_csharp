using System;
using System.Collections.Generic;
using System.Text;

namespace Clientes.Dominio.Entidades
{
    public class Personagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string ResourceURI { get; set; }
        public string UrlImagem { get; set; }
        public string UrlWiki { get; set; }
        public int NumberOfComicsAvailable { get; set; }
        public IList<Comic> Comics { get; set; }
    }
}
