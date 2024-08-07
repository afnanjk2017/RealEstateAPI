using System;
namespace RealEstateAPI.Infrastructure.DTO
{
	public record CreateUserDTO
	{
        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       
        public string Phone { get; set; }
       
    }
}

