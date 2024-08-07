using System;
namespace RealEstateAPI.Infrastructure.DTO
{
	public record UpdateUserDTO : CreateUserDTO
    {
        public Guid Id { get; set; }
        public int NumOfAddedPropertys { get; set; }
        public int Subscription { get; set; }
    }
}

