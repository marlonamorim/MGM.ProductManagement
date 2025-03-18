using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Repository interface for Product entity operations
    /// </summary>
    public interface IProductRepository : IMainRepository<Product>
    {
        /// <summary>
        /// Update a product in the repository
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Assertion if product updated</returns>
        Task<bool> UpdateAsync(Guid id, Product product, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a product by their unique identifier
        /// </summary>
        /// <param name="category">The category of the product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The product if found, null otherwise</returns>
        Task<Product?> GetByCategoryAsync(ProductCategory category, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a collection products by page, size with the possibility of ordering
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="ordering"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Collection products paginated and ordering</returns>
        Task<IEnumerable<Product>> ListPaginatedWithOrderingAsync(int page, int size, IEnumerable<ProductOrdering> ordering, CancellationToken cancellationToken = default);
    }
}
