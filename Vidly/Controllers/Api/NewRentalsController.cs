using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//To eager load the membership type model so we have access to it it calls
using System.Data.Entity;
using Vidly.Models;
using Vidly.DTO;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(RentalDTO newRental)
        {
            var customer = _context.Customers.Single(
                c => c.Id == newRental.CustomerId);


            var movie = _context.Movies.Single(
                m => m.Id == newRental.MovieIds);

            //var movies = _context.Movies.Where(
            // m => newRental.MoviesIds.Contains(m.Id)).ToList();

            /*foreach (var movie in movies)
            {
                //if (movie.NumberAvailable == 0)
                  //  return BadRequest("Movie is not available.");

               // movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rental.Add(rental);
            }*/
            var rental = new Rental
            {
                Customer = customer,
                Movie = movie,
                DateRented = DateTime.Now
            };

            _context.Rental.Add(rental);

            _context.SaveChanges();

            return Ok();
        }
    }
}
