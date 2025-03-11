using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers
{
    /// <summary>
    /// API response model for ListUser operation
    /// </summary>
    public class ListUsersResponse
    {
        /// <summary>
        /// User collection
        /// </summary>
        public IEnumerable<GetUserResponse> Users { get; set; } = [];

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
