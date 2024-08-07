namespace RealEstateAPI.Infrastructure.Models
{
    public class SearchUserDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
      

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
