namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
/// <summary>
/// Represents the response returned after successfully updating a Product.
/// </summary>
/// <remarks>
/// This response contains the assertion if Product updating
/// </remarks>
public class UpdateProductResult
{
    /// <summary>
    /// Gets or sets if Product updating.
    /// </summary>
    /// <value>A bool that assertion if Product updated.</value>
    public bool Updated { get; set; }

    /// <summary>
    /// Initializes a new instance of UpdateProductResult
    /// </summary>
    /// <param name="updated">A bool that assertion if Product updated</param>
    public UpdateProductResult(bool updated)
    {
        Updated = updated;
    }
}
