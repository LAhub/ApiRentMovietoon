using System;
using System.ComponentModel.DataAnnotations;

namespace ApiRentMovietoon.Entities
{
    public class Movie : IId
    {
        public int Id {  get; set; }
        [Required]
        [StringLength(300)]
        public string Title { get; set; }
        public DateTime CreatedDate {  get; set; }
        public DateTime ReleaseDate { get; set; }

        public string Poster { get; set; }

    }
}
