using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Infraestrutura.Interfaces
{
    public interface ICacheRepository<TEntity>
    {
        /// <summary>
        /// Obtém entidade por identificador
        /// </summary>
        Task<TEntity> PegarCacheAsync(string id);

        /// <summary>
        /// Coloca a entidade em cache
        /// </summary>
        Task GravarCacheAsync(string id, TEntity entity, TimeSpan cacheDuration);

        /// <summary>
        /// Remove a entidade do cache
        /// </summary>
        Task RemoverCacheAsync(string id);
    }
}
