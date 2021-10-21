using System.ComponentModel.DataAnnotations;

namespace ApiRentMovietoon.Entities
{
    public class RentDetail : IId
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        [Range(1, 5)]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
       
    }
}
