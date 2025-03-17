using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductCommand that defines validation rules for Product creation command.
/// </summary>
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductCommandValidator with defined validation rules.
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
    public CreateProductCommandValidator()
    {
        RuleFor(Product => Product.Description).NotEmpty().Length(3, int.MaxValue);
        RuleFor(Product => Product.Title).NotEmpty().Length(3, 100);
        RuleFor(Product => Product.Image).NotEmpty();
        RuleFor(Product => Product.Price).NotEmpty();
        RuleFor(Product => Product.Category).NotEqual(ProductCategory.Unknown);
        RuleFor(Product => Product.Rate).NotEmpty();
    }
}