using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;
/// <summary>
/// Command for retrieving a Product by their ID
/// </summary>
public record GetProductCommand : IRequest<GetProductResult>
{
    /// <summary>
    /// The unique identifier of the Product to retrieve
    /// </summary>
    public Guid? Id { get; }

    /// <summary>
    /// The category of the product to retrieve
    /// </summary>
    public ProductCategory? Category { get; set; }

    /// <summary>
    /// Initializes a new instance of GetProductCommand
    /// </summary>
    /// <param name="id">The ID of the Product to retrieve</param>
    public GetProductCommand(Guid? id, ProductCategory? category)
    {
        Id = id;
        Category = category;
    }
}
