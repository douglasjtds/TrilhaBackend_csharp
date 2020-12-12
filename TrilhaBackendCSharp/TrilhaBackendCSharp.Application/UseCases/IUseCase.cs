using System.Collections.Generic;

namespace TrilhaBackendCSharp.Application.UseCases
{
    public interface IUseCase<TRequest>
    {
        void Execute(List<TRequest> request);
    }
}
