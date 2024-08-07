using System;
using System.ComponentModel.DataAnnotations;
namespace RealEstateAPI.Infrastructure.Models
{
	public record UserDTO
	{
        public Guid Id { get; set; }
        public string Name { get; set; }

      

        public string Email { get; set; }

        public string Password { get; set; }

       
        public string Phone { get; set; }
        public int NumOfAddedPropertys { get; set; }
        public int Subscription { get; set; }
    }
}

