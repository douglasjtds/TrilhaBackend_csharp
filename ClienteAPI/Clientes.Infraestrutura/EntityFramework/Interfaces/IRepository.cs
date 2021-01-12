using System;
using System.Linq;

namespace Clientes.Infraestrutura.EntityFramework.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Retorna todos os dados como IQueryable, ou seja, você pode retornar a 
        /// lista e aplicar expressões Lambda para filtrar e classificar dados, por exemplo.
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Retorna todos os dados que atenderem a um critério passado em tempo de execução 
        /// através de uma expressão Lambda.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<TEntity> Get(Func<TEntity, bool> predicate);

        /// <summary>
        /// Irá aplicar um filtro pela chave primária da classe em si.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TEntity Find(params object[] key);

        /// <summary>
        /// Recebe o objeto TEntity para efetuar o Update no banco.
        /// </summary>
        /// <param name="obj"></param>
        void Atualizar(TEntity obj);

        /// <summary>
        /// Chama o método SaveChanges para efetivar todas as alterações no contexto.
        /// </summary>
        void SalvarTodos();

        /// <summary>
        /// Recebe o objeto TEntity para efetuar o Insert no banco.
        /// </summary>
        /// <param name="obj"></param>
        void Adicionar(TEntity obj);

        /// <summary>
        /// Este método irá excluir registros, sendo que a condição é dinâmica através de uma 
        /// expressão Lambda e aplica-se o predicate para a condição passada.
        /// </summary>
        /// <param name="predicate"></param>
        void Excluir(Func<TEntity, bool> predicate);
    }
}
