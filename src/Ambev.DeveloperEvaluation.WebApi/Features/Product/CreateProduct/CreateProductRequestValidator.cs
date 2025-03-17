using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProduct;

/// <summary>
/// Validator for CreateUserRequest that defines validation rules for user creation.
/// </summary>
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductRequestValidator with defined validation rules.
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
    public CreateProductRequestValidator()
    {
        RuleFor(user => user.Description).NotEmpty().Length(3, int.MaxValue);
        RuleFor(user => user.Title).NotEmpty().Length(3, 100);
        RuleFor(user => user.Image).NotEmpty();
        RuleFor(user => user.Price).NotEmpty();
        RuleFor(user => user.Category).NotEqual(ProductCategory.Unknown);
        RuleFor(user => user.Rate).NotEmpty();
    }
}
