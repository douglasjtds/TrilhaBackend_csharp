using System.Collections.Generic;
using TrilhaBackendCSharp.Dominio.Entidades;

namespace TrilhaBackendCSharp.Application.UseCases
{
    public interface IGerarRelatorioUseCase
    {
        void Execute(List<Cliente> request);
    }
}
