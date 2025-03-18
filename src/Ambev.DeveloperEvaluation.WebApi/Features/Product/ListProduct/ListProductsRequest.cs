using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.ListProduct
{
    /// <summary>
    /// Request model for listing a Product by page and size with the possibility of ordering
    /// </summary>
    public class ListProductsRequest
    {
        /// <summary>
        /// Current page number.
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// Lenght page
        /// </summary>
        public int Size { get; set; } = 10;

        /// <summary>
        /// Sorting criteria
        /// </summary>
        public IEnumerable<ProductOrdering> Ordering { get; set; } = [ProductOrdering.Unknown];
    }
}
