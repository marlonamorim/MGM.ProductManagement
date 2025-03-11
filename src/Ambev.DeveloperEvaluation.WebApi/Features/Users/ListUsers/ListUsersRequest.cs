using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers
{
    /// <summary>
    /// Request model for listing a user by page and size with the possibility of ordering
    /// </summary>
    public class ListUsersRequest
    {
        /// <summary>
        /// Current page number.
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// Lenght page
        /// </summary>
        public int Size { get; set; } = 10;

        /// <summary>
        /// Sorting criteria
        /// </summary>
        public IEnumerable<UserOrdering> Ordering { get; set; } = [UserOrdering.Unknown];
    }
}
