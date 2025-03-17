using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    /// <summary>
    /// Command for updating a new product.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for updating a product, 
    /// including title, description, image, price, category, and rate. 
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="UpdateProductResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="UpdateProductCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class UpdateProductCommand : IRequest<UpdateProductResult>
    {
        /// <summary>
        /// The unique identifier of the product to retrieve
        /// </summary>
        public Guid Id { get; }

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

        /// <summary>
        /// Initializes a new instance of UpdateProductCommand
        /// </summary>
        /// <param name="id">The ID of the product to retrieve</param>
        public UpdateProductCommand(Guid id)
        {
            Id = id;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new UpdateProductCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
