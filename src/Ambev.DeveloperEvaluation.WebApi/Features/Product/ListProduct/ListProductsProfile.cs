using Ambev.DeveloperEvaluation.Application.Products.ListProducts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.ListProduct
{
    /// <summary>
    /// Profile for mapping ListProducts feature requests to commands
    /// </summary>
    public class ListProductsProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for ListProducts feature
        /// </summary>
        public ListProductsProfile()
        {
            CreateMap<ListProductsRequest, ListProductsCommand>();
            CreateMap<ListProductsResult, ListProductsResponse>();
        }
    }
}
