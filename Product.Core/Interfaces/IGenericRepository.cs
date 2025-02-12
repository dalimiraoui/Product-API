using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        IEnumerable<T> GetAll();

        /// <summary>
        /// Retrieves all records of type T asynchronously, allowing optional inclusion of related entities.
        /// </summary>
        /// <typeparam name="T">The entity type being retrieved.</typeparam>
        /// <param name="includes">
        /// A variable number of lambda expressions (`Expression<Func<T, bool>>`) that specify related entities
        /// or filtering conditions to be applied to the query.
        /// 
        /// The `params` keyword allows the caller to pass multiple expressions without manually creating an array.
        /// Instead of writing:
        ///     GetAllAsync(new Expression<Func<T, bool>>[] { expr1, expr2 })
        /// The caller can simply write:
        ///     GetAllAsync(expr1, expr2)
        ///
        /// If no expressions are provided, the method should handle it gracefully (e.g., returning all entities).
        /// </param>
        /// <returns>
        /// A task that, when awaited, returns an IEnumerable of T containing the retrieved records.
        /// </returns>
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, bool>>[] includes);


        IEnumerable<T> GetAll(params Expression<Func<T, bool>>[] includes);

        Task<T> GetByIdAsync(T id, params Expression<Func<T, object>>[] includes);

        Task<T> GetAsync(T id);

        Task AddAsync(T Entity);

        Task DeleteAsync(int id);

        Task UpdateAsync(T id, T Entity);
    }
}
