using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.UpdateProduct;

/// <summary>
/// Represents a request to update a Product in the system.
/// </summary>
public class UpdateProductRequest
{
    /// <summary>
    /// The unique identifier of the Product to retrieve
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the product to be updated.
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

    /// <summary>
    /// Gets or sets the rate of the product.
    /// </summary>
    public int RatingCount { get; set; }
}
