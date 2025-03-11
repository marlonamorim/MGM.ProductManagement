using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers
{
    /// <summary>
    /// Command for retrieving a user by page and size with the possibility of ordering
    /// </summary>
    /// <param name="Page"></param>
    /// <param name="Size"></param>
    /// <param name="Order"></param>
    public record ListUsersCommand(int Page, int Size, IEnumerable<UserOrdering> Ordering) : IRequest<ListUsersResult>;
}
