using RealEstateAPI.Infrastructure.DTO;
using RealEstateAPI.Infrastructure.Models;
using RealEstateAPI.Infrastructure.Pagination;

namespace RealEstateAPI.Application.Services
{
    public interface IPropertiesService
    {
        /// <summary>
        /// Create a new user 
        /// </summary>
        /// <param name="model"></param>
        void CreateProperty(CreatePropertyDTO model);

        /// <summary>
        /// Update an exist user
        /// </summary>
        /// <param name="model"></param>
        //void UpdateProperty(UpdatePropertyDTO model);

        /// <summary>
        /// Get list of users
        /// </summary>
        IEnumerable<PropertyDTO> GetProperties();

        /// <summary>
        /// Search by name or email with pagination
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //PaginationResult<PropertyDTO> Search(SearchPropertyDTO model);

        /// <summary>
        /// Get user details by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        PropertyDTO GetPropertyById(Guid propertyId);

        /// <summary>
        /// Delete user - SoftDelete
        /// </summary>
        void DeleteProperty(Guid propertyId);

    }
}
