using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateAPI.Domain.Entities

{
    public class Property : AuditEntity<Guid>
    {
        [Required]

        [StringLength(30)]
        public string OfferType { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public bool Available { get; set; }
        public string? status { get; set; }
        
        public decimal AreaMeters { get; set; }

        //public int Property_Type_id { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string? Description { get; set; }

        public int? Age { get; set; }

        public string? Direction { get; set; }
        public int NumOfRooms { get; set; }
        public int NumOfBathrooms { get; set; }
        public int NumOfFloors { get; set; }
        public string ContactNumber { get; set; }
        public string? OfficeNumber { get; set; }

        public  bool? SchoolService { get; set; }
        public bool? WaterService { get; set; }
        public bool? SupermarketService { get; set; }
        public bool? GasStationService { get; set; }
        public bool? ParkingService { get; set; }
        public bool? PetsService { get; set; }
        public bool? HospitalService { get; set; }
        public bool? ElectricityService { get; set; }

        [ForeignKey("User")]
        public Guid User_id { get; set; }  // Change this to Guid
        public virtual User User { get; set; }


    }
}
