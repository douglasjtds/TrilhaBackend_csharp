using System;
using System.Collections.Generic;
using System.Text;
using TrilhaBackendCSharp.Dominio.Entidades;

namespace TrilhaBackendCSharp.Dominio.Repositorios
{
    public interface IEscreverArquivoRepositorio
    {
        void Escreve(List<Cliente> clientes);
    }
}
