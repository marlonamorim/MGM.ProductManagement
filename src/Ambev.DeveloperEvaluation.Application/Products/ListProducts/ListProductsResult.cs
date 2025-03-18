using Ambev.DeveloperEvaluation.Application.Products.GetProduct;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts;
/// <summary>
/// API response model for ListProduct operation
/// </summary>
public class ListProductsResult
{
    /// <summary>
    /// Product collection
    /// </summary>
    public IEnumerable<GetProductResult> Products { get; set; } = [];

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
