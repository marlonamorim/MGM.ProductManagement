using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers
{
    /// <summary>
    /// Profile for mapping between collection Users entity and ListUsersResponse
    /// </summary>
    public class ListUsersProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for ListUsers operation
        /// </summary>
        public ListUsersProfile()
        {
            CreateMap<IEnumerable<User>, ListUsersResult>()
                .ConstructUsing(collection => new ListUsersResult
                {
                    Users = collection.Select(x => new GetUser.GetUserResult
                    {
                        Email = x.Email,
                        Name = x.Username,
                        Id = x.Id,
                        Phone = x.Phone,
                        Role = x.Role,
                        Status = x.Status
                    })
                });
        }
    }
}
