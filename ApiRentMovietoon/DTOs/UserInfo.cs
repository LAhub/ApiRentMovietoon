using System.ComponentModel.DataAnnotations;

namespace ApiRentMovietoon.DTOs
{
    public class UserInfo
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
