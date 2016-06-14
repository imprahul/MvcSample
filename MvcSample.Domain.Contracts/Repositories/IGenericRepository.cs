using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcSample.Domain.Contracts.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Get the entity based on its Id.
        /// </summary>
        /// <param name="id">Id to get</param>
        /// <returns></returns>
        Task<T> GetById(int id);

        /// <summary>
        /// Get all T objects.
        /// </summary>
        /// <returns></returns>
        Task<IList<T>> GetAll();

        /// <summary>
        /// Save T entity.
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns></returns>
        Task Create(T entity);

        /// <summary>
        /// Update the T entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns></returns>
        Task Update(T entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="id">Id to delete</param>
        /// <returns></returns>
        Task Delete(int id);
    }
}