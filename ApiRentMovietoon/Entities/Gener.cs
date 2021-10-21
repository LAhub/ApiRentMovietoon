using System.ComponentModel.DataAnnotations;

namespace ApiRentMovietoon.Entities
{
    public class Gener: IId
    {
        public int Id {  get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
         
    }
}
