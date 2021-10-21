using Microsoft.AspNetCore.Identity;

namespace ApiRentMovietoon.Entities
{
    public class Rent : IId
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
