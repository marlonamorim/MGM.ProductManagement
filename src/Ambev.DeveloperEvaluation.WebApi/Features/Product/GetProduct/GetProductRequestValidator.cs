﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProduct;

/// <summary>
/// Validator for GetProductRequest
/// </summary>
public class GetProductRequestValidator : AbstractValidator<GetProductRequest>
{
    /// <summary>
    /// Initializes validation rules for GetProductRequest
    /// </summary>
    public GetProductRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .When(x => x.Category is null)
            .WithMessage("Product ID is required");
    }
}
