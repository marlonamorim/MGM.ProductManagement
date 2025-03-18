using Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProduct;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.ListProduct
{
    /// <summary>
    /// API response model for ListProduct operation
    /// </summary>
    public class ListProductsResponse
    {
        /// <summary>
        /// Product collection
        /// </summary>
        public IEnumerable<GetProductResponse> Products { get; set; } = [];

        /// <summary>
        /// Total items on page
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Current page number
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Total number of pages
        /// </summary>
        public int TotalPages { get; set; }
    }
}
