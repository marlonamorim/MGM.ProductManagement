using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts
{
    /// <summary>
    /// Profile for mapping between collection Products entity and ListProductsResponse
    /// </summary>
    public class ListProductsProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for ListProducts operation
        /// </summary>
        public ListProductsProfile()
        {
            CreateMap<IEnumerable<Product>, ListProductsResult>()
                .ConstructUsing(collection => new ListProductsResult
                {
                    Products = collection.Select(x => new GetProduct.GetProductResult
                    {
                        Title = x.Title,
                        Description = x.Description,
                        Id = x.Id,
                        Price = x.Price,
                        Rate = x.Rate,
                        RatingCount = x.RatingCount,
                        Image = x.Image,
                        Category = x.Category
                    })
                });
        }
    }
}
