using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProduct;

/// <summary>
/// Command for retrieving a Product by their ID and Category
/// </summary>
public record GetProductRequest
{
    /// <summary>
    /// The unique identifier of the Product to retrieve
    /// </summary>
    public Guid? Id { get; set; }

    /// <summary>
    /// The category of the product to retrieve
    /// </summary>
    public ProductCategory? Category { get; set; }
}
