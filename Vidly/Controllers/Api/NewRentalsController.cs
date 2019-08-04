using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            //intializing _context in constructor
            _context = new ApplicationDbContext();
            //after this we need to dispose this by override

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerID);
            var movies = _context.Movie.Where(m => newRental.MoviesIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("No Movies Available");

                movie.NumberAvailable--;
               
                    var rental = new Rental
                {
                    
                
                    Customer = customer,
                    Movies = movie,
                    DateRented = DateTime.Now
                
                };


                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }

        public IHttpActionResult UpdateNewRentals(int id)
        {
            return Ok();
        }
    }
}
