using System;
using System.Collections.Generic;
using System.Text;
using TrilhaBackendCSharp.Dominio.Entidades;

namespace TrilhaBackendCSharp.Infraestrutura.Repositorios
{
    public class EscreverArquivoRepositorio
    {
        public void Escreve(List<Cliente> clientes)
        {
            foreach (var cliente in clientes)
            {
                //escrever no arquivo txt
                System.IO.File.WriteAllText(@"D:\Users\douglasjtds\Projects\estudandoBackend\TrilhaBackend_csharp\clientes.txt", cliente.Imprimir);
            }
        }
    }
}
