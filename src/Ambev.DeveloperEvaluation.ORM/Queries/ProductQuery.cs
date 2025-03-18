using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.ORM.Queries
{
    public static class ProductQuery
    {
        public static IQueryable<Product> OrderByProductOrdering(this IQueryable<Product> query, IEnumerable<ProductOrdering> ordering)
        {
            IOrderedQueryable<Product> productOrdering = query.OrderByDescending(x => x.CreatedAt);
            foreach (var order in ordering.Select((value, i) => new { i, value }))
            {
                var value = order.value;
                var index = order.i;

                switch (value)
                {
                    case ProductOrdering.PriceAsc:
                        productOrdering = index == 0 ? productOrdering.OrderBy(o => o.Price) : productOrdering.ThenBy(o => o.Price);
                        break;
                    case ProductOrdering.PriceDesc:
                        productOrdering = index == 0 ? productOrdering.OrderByDescending(o => o.Price) : productOrdering.ThenByDescending(o => o.Price);
                        break;
                    case ProductOrdering.RatingAsc:
                        productOrdering = index == 0 ? productOrdering.OrderBy(o => o.Rate) : productOrdering.ThenBy(o => o.Rate);
                        break;
                    case ProductOrdering.RatingDesc:
                        productOrdering = index == 0 ? productOrdering.OrderByDescending(o => o.Rate) : productOrdering.ThenByDescending(o => o.Rate);
                        break;
                    case ProductOrdering.TitleAsc:
                        productOrdering = index == 0 ? productOrdering.OrderBy(o => o.Title) : productOrdering.ThenBy(o => o.Title);
                        break;
                    case ProductOrdering.TitleDesc:
                        productOrdering = index == 0 ? productOrdering.OrderByDescending(o => o.Title) : productOrdering.ThenByDescending(o => o.Title);
                        break;
                    default:
                        break;
                }
            }

            query = productOrdering;
            return query;
        }
    }
}
