using Ambev.DeveloperEvaluation.Application.Users.GetUser;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers
{
    /// <summary>
    /// API response model for ListUser operation
    /// </summary>
    public class ListUsersResult
    {
        /// <summary>
        /// User collection
        /// </summary>
        public IEnumerable<GetUserResult> Users { get; set; } = [];

        /// <summary>
        /// Total items on page
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Current page number
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Total number of pages
        /// </summary>
        public int TotalPages { get; set; }
    }
}
