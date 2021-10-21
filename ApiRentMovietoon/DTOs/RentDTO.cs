using Microsoft.AspNetCore.Identity;

namespace ApiRentMovietoon.DTOs
{
    public class RentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UsuarioId { get; set; }
        public IdentityUser User { get; set; }
    }
}
