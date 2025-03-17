using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
/// <summary>
/// Handler for processing CreateProductCommand requests
/// </summary>
public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateProductHandler
    /// </summary>
    /// <param name="ProductRepository">The Product repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateProductCommand</param>
    public UpdateProductHandler(IProductRepository ProductRepository, IMapper mapper)
    {
        _productRepository = ProductRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateProductCommand request
    /// </summary>
    /// <param name="command">The CreateProduct command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Product details</returns>
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        _ = await _productRepository.GetByIdAsync(command.Id, cancellationToken) ?? throw new InvalidOperationException($"There is not Product with the provider identifier {command.Id}");

        var product = _mapper.Map<Product>(command);

        var updatedProduct = await _productRepository.UpdateAsync(product.Id, product, cancellationToken);
        var result = _mapper.Map<UpdateProductResult>(updatedProduct);
        return result;
    }
}
