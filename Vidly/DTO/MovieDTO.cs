using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter the movie name")]
        [StringLength(255)]
        public string Name { get; set; }
        public byte GenreTypeId { get; set; }
        public GenreDTO Genre { get; set; }
        public DateTime? ReleaseDate { get; set; }
        [Range(1, 20)]
        public int NumberInStock { get; set; }
        public int NumberAvailable { get; set; }
    }
}