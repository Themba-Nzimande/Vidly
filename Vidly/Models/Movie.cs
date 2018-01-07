using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter the movie name")]
        [StringLength(255)]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        [Required]
        public byte GenreTypeId { get; set; }
        public DateTime? ReleaseDate { get; set; }
        [Required(ErrorMessage = "Enter the number of copies in stock")]
        [Range(1, 20)]
        public int NumberInStock { get; set; }
        public int NumberAvailable { get; set; }
    }
}