using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers
{
    /// <summary>
    /// Initializes a new instance of ListUsersHandler
    /// </summary>
    /// <param name="userRepository"></param>
    /// <param name="mapper"></param>
    public class ListUsersHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<ListUsersCommand, ListUsersResult>
    {
        /// <summary>
        /// Handles the ListUsersCommand request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ListUsersResult> Handle(ListUsersCommand request, CancellationToken cancellationToken)
        {
            var users = await userRepository.ListPaginatedAsync(request.Page, request.Size, request.Ordering, cancellationToken);
            
            return mapper.Map<ListUsersResult>(users);
        }
    }
}
