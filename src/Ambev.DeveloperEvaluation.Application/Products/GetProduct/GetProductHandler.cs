using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;
/// <summary>
/// Handler for processing GetProductCommand requests
/// </summary>
public class GetProductHandler : IRequestHandler<GetProductCommand, GetProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetProductHandler
    /// </summary>
    /// <param name="ProductRepository">The Product repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetProductCommand</param>
    public GetProductHandler(
        IProductRepository ProductRepository,
        IMapper mapper)
    {
        _productRepository = ProductRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetProductCommand request
    /// </summary>
    /// <param name="request">The GetProduct command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Product details if found</returns>
    public async Task<GetProductResult> Handle(GetProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetProductValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        Product? product;
        if (request.Id.HasValue)
            product = await _productRepository.GetByIdAsync(request.Id.Value, cancellationToken);
        else
            product = await _productRepository.GetByCategoryAsync(request.Category!.Value, cancellationToken);

        var filterSearch = request.Id.HasValue ? "ID" : "Category";
        var valueSearch = request.Id.HasValue ? request.Id.Value.ToString() : request.Category!.Value.ToString();

        return product == null
                ? throw new KeyNotFoundException($"Product with {filterSearch} {valueSearch} not found")
                : _mapper.Map<GetProductResult>(product);
    }
}
