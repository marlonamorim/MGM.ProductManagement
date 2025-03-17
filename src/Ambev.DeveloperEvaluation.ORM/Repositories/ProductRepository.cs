using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of IProductRepository using Entity Framework Core
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of ProductRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public ProductRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new product in the database
        /// </summary>
        /// <param name="product">The product to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created product</returns>
        public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
        {
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }

        /// <summary>
        /// Update a product in the database
        /// </summary>
        /// <param name="product">The product to update</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Assertion if Product updated</returns>
        public async Task<bool> UpdateAsync(Guid id, Product product, CancellationToken cancellationToken = default)
        {
            var productToUpdate = await GetByIdAsync(id, cancellationToken);
            if (productToUpdate is null)
                return false;

            productToUpdate.Update(product.Title, product.Price, product.Description, product.Category, product.Image, product.Rate, product.RatingCount);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        /// <summary>
        /// Retrieves a Product by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the Product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Product if found, null otherwise</returns>
        public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Products.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }
    }
}
