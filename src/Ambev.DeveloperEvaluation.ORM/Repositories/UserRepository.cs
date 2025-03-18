using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Queries;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IUserRepository using Entity Framework Core
/// </summary>
public class UserRepository : MainRepository<User>, IUserRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of UserRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public UserRepository(DefaultContext context) : base(context)
    {
        _context = context;
    }

    /// <summary>
    /// Update a user in the database
    /// </summary>
    /// <param name="user">The user to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Assertion if user updated</returns>
    public async Task<bool> UpdateAsync(Guid id, User user, CancellationToken cancellationToken = default)
    {
        var userToUpdate = await GetByIdAsync(id, cancellationToken);
        if (userToUpdate is null)
            return false;

        userToUpdate.Update(user.Username, user.Email, user.Phone, user.Password);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Retrieves a user by their email address
    /// </summary>
    /// <param name="email">The email address to search for</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user if found, null otherwise</returns>
    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    /// <summary>
    /// Retrieves a collection users by page, size with possibility of ordering
    /// </summary>
    /// <param name="page"></param>
    /// <param name="size"></param>
    /// <param name="order"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>The users if found</returns>
    public async Task<IEnumerable<User>> ListPaginatedWithOrderingAsync(int page, int size, IEnumerable<UserOrdering> ordering, CancellationToken cancellationToken = default)
    {
        var query = PageAsync(page, size);
        query = query.OrderByUserOrdering(ordering);

        return await query.ToListAsync(cancellationToken);
    }
}
