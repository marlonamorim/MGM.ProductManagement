using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts
{
    /// <summary>
    /// Initializes a new instance of ListProductsHandler
    /// </summary>
    /// <param name="ProductRepository"></param>
    /// <param name="mapper"></param>
    public class ListProductsHandler(IProductRepository ProductRepository, IMapper mapper) : IRequestHandler<ListProductsCommand, ListProductsResult>
    {
        /// <summary>
        /// Handles the ListProductsCommand request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ListProductsResult> Handle(ListProductsCommand request, CancellationToken cancellationToken)
        {
            var Products = await ProductRepository.ListPaginatedWithOrderingAsync(request.Page, request.Size, request.Ordering, cancellationToken);

            return mapper.Map<ListProductsResult>(Products);
        }
    }
}
