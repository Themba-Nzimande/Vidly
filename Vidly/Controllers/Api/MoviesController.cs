using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Vidly.Models;
using Vidly.DTO;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //Calling url for this API function is /api/customers
        public IEnumerable<MovieDTO> GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.Genre);
                //.Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            return moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDTO>);
        }

        //Calling url for this API function is /api/customers/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        //POST /api/customer (customer object data)
        [HttpPost]
        //Use IHttpActionResult for CRUD API functions because the response gives more info eg instead of 200 Success it'll say 201 created for a create API call
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDTO.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDTO);
        }

        // PUT /api/customer/id (customer object data)
        [HttpPut]
        public void UpdateMovie(int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());
            }

            var movieInDb = _context.Movies.Single(c => c.Id == id);

            if (movieInDb == null)
            {
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());
            }

            Mapper.Map(movieDTO, movieInDb);
            //Code commented out below is replaced by the mapping code above *_*
            /*customerInDb.Name = customerDTO.Name;
            customerInDb.MembershipTypeId = customerDTO.MembershipTypeId;
            customerInDb.IsSubscribedToNewsLetter = customerDTO.IsSubscribedToNewsLetter;
            customerInDb.BirthDate = customerDTO.BirthDate;*/

            _context.SaveChanges();
        }

        // DELETE /api/customer/id
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.Single(c => c.Id == id);

            if (movieInDb == null)
            {
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());
            }

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
