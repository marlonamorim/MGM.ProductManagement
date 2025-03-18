using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public abstract class MainRepository<T>(DefaultContext context) : IMainRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Retrieves a collection users by page and size
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns>The users if found</returns>
        public IQueryable<T> PageAsync(int page, int size)
        {
            page = page == 0 ? 1 : page;

            var query = context.Set<T>()
                .Skip((page - 1) * size)
                .Take(size);

            return query;
        }

        /// <summary>
        /// Retrieves a entity by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the entity</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The entity if found, null otherwise</returns>
        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await context.Set<T>().FindAsync(id, cancellationToken);

        /// <summary>
        /// Creates a new entity in the database
        /// </summary>
        /// <param name="entity">The entity to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created entity</returns>
        public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        ///// <summary>
        ///// Deletes a user from the database
        ///// </summary>
        ///// <param name="id">The unique identifier of the user to delete</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns>True if the user was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entityToRemove = await GetByIdAsync(id);
            if (entityToRemove is not null)
            {
                context.Set<T>().Remove(entityToRemove);
                await context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
    }
}
