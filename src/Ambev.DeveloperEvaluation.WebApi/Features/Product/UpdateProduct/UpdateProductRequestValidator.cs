using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.UpdateProduct;

/// <summary>
/// Validator for UpdateProductRequest that defines validation rules for Product updation.
/// </summary>
public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the UpdateProductCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Description: Required, must be between 3 and max value integer
    /// - Title: Required, must be between 3 and 100 characters
    /// - Image: Cannot be empty
    /// - Price: Cannot be empty
    /// - Category: Cannot be set to Unknown
    /// - Rate: Cannot be empty
    /// </remarks>
    public UpdateProductRequestValidator()
    {
        RuleFor(Product => Product.Description).NotEmpty().Length(3, int.MaxValue);
        RuleFor(Product => Product.Title).NotEmpty().Length(3, 100);
        RuleFor(Product => Product.Image).NotEmpty();
        RuleFor(Product => Product.Price).NotEmpty();
        RuleFor(Product => Product.Category).NotEqual(ProductCategory.Unknown);
        RuleFor(Product => Product.Rate).NotEmpty();
        RuleFor(Product => Product.RatingCount).NotEmpty();
    }
}
