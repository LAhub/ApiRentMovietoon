using Microsoft.AspNetCore.Identity;

namespace ApiRentMovietoon.Entities
{
    public class User : IdentityUser
    {
        public bool active { get; set; }

    }
}
