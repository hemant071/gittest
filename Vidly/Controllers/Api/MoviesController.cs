using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using System.Data.Entity;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetMovies(string query = null)
        {

            var moviesQuery = _context.Movie
                .Include(m =>m.Genre);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            var moviesDtos = moviesQuery
                .ToList()
                .Select(Mapper.Map<Movies, MoviesDto>);

            return Ok(moviesDtos);
        }

        public IHttpActionResult GetMovies(int id)
        {
            var movies = _context.Movie.FirstOrDefault(m => m.Id == id);
            if (movies == null)
            {


                return NotFound();

            } 

            return Ok( Mapper.Map<Movies,MoviesDto> (movies));
        }
        [HttpPost]
        public IHttpActionResult CreateMovies(MoviesDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movies = Mapper.Map< MoviesDto, Movies> (movieDto);
            _context.Movie.Add(movies);
            _context.SaveChanges();
            movieDto.Id = movies.Id;
            return Created(new Uri(Request.RequestUri + "/" +movies.Id),movieDto);

        }

        [HttpPut]
        public void MoviesUpdate(int id,MoviesDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var MoviesInDb = _context.Movie.SingleOrDefault(m => m.Id == id);

            if (MoviesInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(movieDto, MoviesInDb);
          
           
            _context.SaveChanges();

           

        }
        [HttpDelete]
        public void MoviesDelete(int id)
        {
            var MoviesInDb = _context.Movie.SingleOrDefault(m => m.Id == id);

            if (MoviesInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movie.Remove(MoviesInDb);
            _context.SaveChanges();     
        }




    }
}
