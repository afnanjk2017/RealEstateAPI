using Microsoft.AspNetCore.Mvc;
using RealEstateAPI.Application.Services;
using RealEstateAPI.Infrastructure.DTO;
using RealEstateAPI.Infrastructure.Enum;
using RealEstateAPI.Infrastructure.Models;
using RealEstateAPI.Infrastructure;
using System.Net;

namespace RealEstateAPI.Presentation.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertiesService _propertiesService;

        public PropertyController(IPropertiesService PropertiesService)
        {
            _propertiesService = PropertiesService;
        }

        [HttpPost]
        public ServiceResponse CreateProperty(CreatePropertyDTO property)
        {
            try
            {
                _propertiesService.CreateProperty(property);
                return ServiceResponse.GetResponseMessage(ResponseCode.Success, HttpStatusCode.Created, "property has been added successfully");
            }
            catch
            {
                return ServiceResponse.GetResponseMessage(ResponseCode.Exception, HttpStatusCode.InternalServerError, "An error occur");

            }
        }



        [HttpGet]
        public ServiceResponse GetProperties()
        {
            var data = _propertiesService.GetProperties();
            return ServiceResponse.GetResponseMessage(ResponseCode.Success, HttpStatusCode.Accepted, data, "Data retrieved successfully");

        }

        [HttpGet("{id}")]
        public ServiceResponse GetPropertyById(Guid id)
        {
            var data = _propertiesService.GetPropertyById(id);
            if (data is null)
                return ServiceResponse.GetResponseMessage(ResponseCode.NotFound, HttpStatusCode.NotFound, "property is not found");
            return ServiceResponse.GetResponseMessage(ResponseCode.Success, HttpStatusCode.Accepted, data, "Data retrieved successfully");

        }

        [HttpDelete("{id}")]
        public ServiceResponse DeleteProperty(Guid id)
        {
            _propertiesService.DeleteProperty(id);
            return ServiceResponse.GetResponseMessage(ResponseCode.Success, HttpStatusCode.Accepted, "property has been deleted successfully");

        }
    }
}
