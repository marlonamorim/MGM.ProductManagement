using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for User entity operations
/// </summary>
public interface IUserRepository : IMainRepository<User>
{
    /// <summary>
    /// Update a user in the repository
    /// </summary>
    /// <param name="id"></param>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Assertion if user updated</returns>
    Task<bool> UpdateAsync(Guid id, User user, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a collection users by page, size with the possibility of ordering
    /// </summary>
    /// <param name="page"></param>
    /// <param name="size"></param>
    /// <param name="ordering"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Collection users paginated and ordering</returns>
    Task<IEnumerable<User>> ListPaginatedWithOrderingAsync(int page, int size, IEnumerable<UserOrdering> ordering, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a user by their email address
    /// </summary>
    /// <param name="email">The email address to search for</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user if found, null otherwise</returns>
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
}
