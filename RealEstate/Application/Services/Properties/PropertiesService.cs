using RealEstateAPI.Context;
using RealEstateAPI.Domain.Entities;
using RealEstateAPI.Infrastructure.DTO;
using RealEstateAPI.Infrastructure.Models;
using RealEstateAPI.Infrastructure.Pagination;
using System.Numerics;

namespace RealEstateAPI.Application.Services
{
    public class PropertiesService : IPropertiesService
    {
        private readonly AppDbContext _context;

        public PropertiesService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateProperty(CreatePropertyDTO model)
        {
            var property = new Property
            {
                Id = Guid.NewGuid(),
                Available = model.Available ,
                status = model.status,
                Age = model.Age,
                OfferType = model.OfferType,
                Title = model.Title,
                AreaMeters = model.AreaMeters,
                Price = model.Price,
                Location = model.Location,
                Description = model.Description,
                Direction = model.Direction,
                NumOfRooms = model.NumOfRooms,
                NumOfBathrooms = model.NumOfBathrooms,
                NumOfFloors = model.NumOfFloors,
                ContactNumber = model.ContactNumber,
                OfficeNumber = model.OfficeNumber,
                SchoolService = model.SchoolService,
                WaterService = model.WaterService,
                SupermarketService = model.SupermarketService,
                GasStationService = model.GasStationService,
                ParkingService = model.ParkingService,
                PetsService = model.PetsService,
                HospitalService = model.HospitalService,
                ElectricityService = model.ElectricityService,
                User_id = model.User_id,
                CreationDatetime = DateTime.Now,
            };
            _context.Properties.Add(property);
            _context.SaveChanges();
        }





        public IEnumerable<PropertyDTO> GetProperties()
        {
            var Properties = _context.Properties;
            var data = Properties.Select(u => new PropertyDTO
            {
                Id = u.Id,
                OfferType = u.OfferType,
                Title = u.Title,
               
                AreaMeters = u.AreaMeters,
                Available = u.Available,
                status = u.status,
                //Property_Type_id = u.Property_Type_id,
                Price = u.Price,
                Location = u.Location,
                Description = u.Description,
                Age = u.Age,
                Direction = u.Direction,
                NumOfRooms = u.NumOfRooms,
                NumOfBathrooms = u.NumOfBathrooms,
                NumOfFloors = u.NumOfFloors,
                ContactNumber = u.ContactNumber,
                OfficeNumber = u.OfficeNumber,
                SchoolService = u.SchoolService,
                WaterService = u.WaterService,
                SupermarketService = u.SupermarketService,
                GasStationService = u.GasStationService,
                ParkingService = u.ParkingService,
                PetsService = u.PetsService,
                HospitalService = u.HospitalService,
                ElectricityService = u.ElectricityService,
                User_id = u.User_id
            }).ToList();
            return data;
        }




        public PropertyDTO GetPropertyById(Guid propertyId)
        {
            var property = _context.Properties.FirstOrDefault(u => u.Id == propertyId);
            if (property is null)
                return null;
            return new PropertyDTO
            {
                Id = property.Id,
                OfferType = property.OfferType,
                Title = property.Title,
                Available = property.Available,
                status = property.status,
                AreaMeters = property.AreaMeters,
                //Property_Type_id = u.Property_Type_id,
                Price = property.Price,
                Location = property.Location,
                Description = property.Description,
                Age = property.Age,
                Direction = property.Direction,
                NumOfRooms = property.NumOfRooms,
                NumOfBathrooms = property.NumOfBathrooms,
                NumOfFloors = property.NumOfFloors,
                ContactNumber = property.ContactNumber,
                OfficeNumber = property.OfficeNumber,
                SchoolService = property.SchoolService,
                WaterService = property.WaterService,
                SupermarketService = property.SupermarketService,
                GasStationService = property.GasStationService,
                ParkingService = property.ParkingService,
                PetsService = property.PetsService,
                HospitalService = property.HospitalService,
                ElectricityService = property.ElectricityService,
                User_id = property.User_id
            };
        }


        public void DeleteProperty(Guid propertyId)
        {
            var property = _context.Properties.FirstOrDefault(u => u.Id == propertyId);
            if (property is not null)
            {
                property.IsDeleted = true;
                property.DeletedDateTime = DateTime.Now;
                _context.Properties.Update(property);
                _context.SaveChanges();
            }
        }


    }
}
