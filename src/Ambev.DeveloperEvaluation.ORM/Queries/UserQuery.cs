using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.ORM.Queries
{
    public static class UserQuery
    {
        public static IQueryable<User> OrderByUserOrdering(this IQueryable<User> query, IEnumerable<UserOrdering> ordering)
        {
            IOrderedQueryable<User> userOrdering = query.OrderByDescending(x => x.CreatedAt);
            foreach (var order in ordering.Select((value, i) => new { i, value }))
            {
                var value = order.value;
                var index = order.i;

                switch (value)
                {
                    case UserOrdering.EmailAsc:
                        userOrdering = index == 0 ? userOrdering.OrderBy(o => o.Email) : userOrdering.ThenBy(o => o.Email);
                        break;
                    case UserOrdering.EmailDesc:
                        userOrdering = index == 0 ? userOrdering.OrderByDescending(o => o.Email) : userOrdering.ThenByDescending(o => o.Email);
                        break;
                    case UserOrdering.UsernameAsc:
                        userOrdering = index == 0 ? userOrdering.OrderBy(o => o.Username) : userOrdering.ThenBy(o => o.Username);
                        break;
                    case UserOrdering.UsernameDesc:
                        userOrdering = index == 0 ? userOrdering.OrderByDescending(o => o.Username) : userOrdering.ThenByDescending(o => o.Username);
                        break;
                    default:
                        break;
                }
            }

            query = userOrdering;
            return query;
        }
    }
}
