using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts
{
    /// <summary>
    /// Command for retrieving a Product by page and size with the possibility of ordering
    /// </summary>
    /// <param name="Page"></param>
    /// <param name="Size"></param>
    /// <param name="Order"></param>
    public record ListProductsCommand(int Page, int Size, IEnumerable<ProductOrdering> Ordering) : IRequest<ListProductsResult>;
}
