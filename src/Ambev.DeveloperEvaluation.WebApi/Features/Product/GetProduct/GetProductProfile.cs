using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Domain.Enums;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProduct;

/// <summary>
/// Profile for mapping GetProduct feature requests to commands
/// </summary>
public class GetProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetProduct feature
    /// </summary>
    public GetProductProfile()
    {
        CreateMap<Guid, GetProductCommand>()
            .ConstructUsing(t => new GetProductCommand(t, null));
        CreateMap<ProductCategory, GetProductCommand>()
            .ConstructUsing(t => new GetProductCommand(null, t));
        CreateMap<GetProductResult, GetProductResponse>();
    }
}
