using RealEstateAPI.Infrastructure.DTO;
using RealEstateAPI.Infrastructure.Models;
using RealEstateAPI.Infrastructure.Pagination;

namespace RealEstateAPI.Application.Services
{
    public interface IUsersService
    {
        /// <summary>
        /// Create a new user 
        /// </summary>
        /// <param name="model"></param>
        void CreateUser(CreateUserDTO model);

        /// <summary>
        /// Update an exist user
        /// </summary>
        /// <param name="model"></param>
        void UpdateUser(UpdateUserDTO model);

        /// <summary>
        /// Get list of users
        /// </summary>
        IEnumerable<UserDTO> GetUsers();

        /// <summary>
        /// Search by name or email with pagination
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        PaginationResult<UserDTO> Search(SearchUserDTO model);

        /// <summary>
        /// Get user details by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        UserDTO GetUserById(Guid userId);

        /// <summary>
        /// Delete user - SoftDelete
        /// </summary>
        void DeleteUser(Guid userId);


    }
}