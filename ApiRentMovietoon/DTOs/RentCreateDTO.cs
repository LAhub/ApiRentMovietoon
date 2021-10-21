using Microsoft.AspNetCore.Identity;

namespace ApiRentMovietoon.DTOs
{
    public class RentCreateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
