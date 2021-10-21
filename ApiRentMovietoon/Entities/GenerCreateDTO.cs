using System.ComponentModel.DataAnnotations;

namespace ApiRentMovietoon.Entities
{
    public class GenerCreateDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

    }
}
