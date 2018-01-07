using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }
        [Required(ErrorMessage = "Enter the movie name")]
        [StringLength(255)]
        public string Name { get; set; }
        public byte? GenreTypeId { get; set; }
        public DateTime? ReleaseDate { get; set; }
        [Required(ErrorMessage = "Enter the number of copies in stock")]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreTypeId = movie.GenreTypeId;
            NumberInStock = movie.NumberInStock;
        }
    }
}