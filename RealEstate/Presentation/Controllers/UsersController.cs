using Microsoft.AspNetCore.Mvc;
using RealEstateAPI.Application.Services;
using RealEstateAPI.Infrastructure;
using RealEstateAPI.Infrastructure.DTO;
using RealEstateAPI.Infrastructure.Enum;
using RealEstateAPI.Infrastructure.Models;
using System.Net;

namespace RealEstateAPI.Presentation.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        public ServiceResponse CreateUser(CreateUserDTO user)
        {
            try
            {
                _usersService.CreateUser(user);
                return ServiceResponse.GetResponseMessage(ResponseCode.Success, HttpStatusCode.Created, "User has been added successfully");
            }
            catch
            {
                return ServiceResponse.GetResponseMessage(ResponseCode.Exception, HttpStatusCode.InternalServerError, "An error occur");

            }
        }

        [HttpPut]
        public ServiceResponse UpdateUser(UpdateUserDTO user)
        {
            _usersService.UpdateUser(user);
            return ServiceResponse.GetResponseMessage(ResponseCode.Success, HttpStatusCode.Accepted, "User has been updated successfully");

        }

        [HttpGet]
        public ServiceResponse GetUsers()
        {
            var data = _usersService.GetUsers();
            return ServiceResponse.GetResponseMessage(ResponseCode.Success, HttpStatusCode.Accepted, data, "Data retrieved successfully");

        }
        [HttpGet("Search")]
        public ServiceResponse SearchUsers([FromQuery] SearchUserDTO model)
        {
            var data = _usersService.Search(model);
            return ServiceResponse.GetResponseMessage(ResponseCode.Success, HttpStatusCode.Accepted, data, "Data retrieved successfully");

        }
        [HttpGet("{id}")]
        public ServiceResponse GetUserById(Guid id)
        {
            var data = _usersService.GetUserById(id);
            if (data is null)
                return ServiceResponse.GetResponseMessage(ResponseCode.NotFound, HttpStatusCode.NotFound, "User is not found");
            return ServiceResponse.GetResponseMessage(ResponseCode.Success, HttpStatusCode.Accepted, data, "Data retrieved successfully");

        }

        [HttpDelete("{id}")]
        public ServiceResponse DeleteUser(Guid id)
        {
            _usersService.DeleteUser(id);
            return ServiceResponse.GetResponseMessage(ResponseCode.Success, HttpStatusCode.Accepted, "User has been deleted successfully");

        }
    }
}