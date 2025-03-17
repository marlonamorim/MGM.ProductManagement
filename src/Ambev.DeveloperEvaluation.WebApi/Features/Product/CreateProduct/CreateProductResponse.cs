using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProduct
{
    /// <summary>
    /// API response model for CreateProduct operation
    /// </summary>

    public class CreateProductResponse
    {
        /// <summary>
        /// The unique identifier of the created user
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the product to be created.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description for the product.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the image for the product.
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the price for the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the category of the product.
        /// </summary>
        public ProductCategory Category { get; set; }

        /// <summary>
        /// Gets or sets the rate of the product.
        /// </summary>
        public int Rate { get; set; }
    }
}
