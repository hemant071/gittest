using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            //intializing _context in constructor
            _context = new ApplicationDbContext();
            //after this we need to dispose this by override

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        [Authorize]
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies) || User.IsInRole(RoleName.StoreManager))
                return View("Index");
            return View("ReadOnlyList");
            // var Movies = _context.Movies.Include(a => a.Genre).ToList();
            //return View();

        }


       // [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult MoviesForm()
        {
            var genre = _context.Genre.ToList();



       

            var viewModel = new MovieFormViewModel
            {
                Genre = genre
            };

            return View("MoviesForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Save(Movies movie)
        {
            if (ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genre = _context.Genre.ToList()
                };
                return View("MoviesForm", viewModel);
            }
            if (movie.Id == 0)
                _context.Movie.Add(movie);

            //if (!ModelState.IsValid)
            //{
            //    if (movie.Id == 0)D:\vidly-mvc-5-b727a26e1b4b88abe84a8b48208fec537db2ed43\Vidly\Migrations\201907102035459_AddMoviesAndGenre.cs
            //{
            //    movie.DateAdded = DateTime.Now;
            //    _context.Movies.Add(movie);
            //}


            else
            {
                var MoviesDB = _context.Movie.Single(m => m.Id == movie.Id);
                MoviesDB.Name = movie.Name;
                MoviesDB.ReleasedDate = movie.ReleasedDate;
                MoviesDB.GenreId = movie.GenreId;
                MoviesDB.NoInStock = movie.NoInStock;
            }


            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }








        public ActionResult Details(int Id)
        {

            // var Movie = _context.Movies.(m => m.Id == Id);

            var Movie = _context.Movie.Include(g => g.Genre).SingleOrDefault(c => c.Id == Id);

            return View(Movie);

        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movie.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genre = _context.Genre.ToList()
            };
            return View("MoviesForm", viewModel);
        }


        public ActionResult Genre()
        {

            var genre = _context.Genre.ToList();

            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Genre", genre);

            return View("GenreList", genre);


        }

        public ActionResult GenreForm()
        {


            var genre = new Genre();
            var dateTime = DateTime.Now;

            genre.DateUpdated = dateTime.Date;

            return View(genre);
        }

        public ActionResult GenreDetails(int id)
        {
            var genre = _context.Genre.SingleOrDefault(g => g.Id == id);

            var movies = _context.Movie.Where(m => m.GenreId == id).ToList();




            var viewModel = new GenreViewModel

            {
                Genre = genre,
                Movies = movies

            };
            return View(viewModel);

        }

        public ActionResult GenreEdit(int id)
        {
            var genre = _context.Genre.FirstOrDefault(g => g.Id == id);

            var viemodel = new GenreViewModel
            {
                Genre=genre

            };
            

                return View("GenreForm","viewmodel");
        }

        public ActionResult Delete(int id)
        {
            var genre = _context.Genre.SingleOrDefault(c => c.Id == id);
            _context.Genre.Remove(genre);
            _context.SaveChanges();

            return RedirectToAction("Genre", genre);

        }

        public ActionResult Saves(Genre genre)
        {
            if (!ModelState.IsValid)
            {

                return View("Genresform");
            }
                if (genre.Id == 0)
                {

                    var id = _context.Genre.Max(g => g.Id);

                    genre.Id = ++id;
                    _context.Genre.Add(genre);
                }


            else
            {
                var GenresDB = _context.Genre.FirstOrDefault(m => m.Id == genre.Id);
                GenresDB.Id = genre.Id;
                GenresDB.Name = genre.Name;
                GenresDB.DateAdded = genre.DateAdded;
                GenresDB.DateUpdated = genre.DateUpdated;


            }
            _context.SaveChanges();
            return RedirectToAction("Genre", genre);




        }



    }
}



//using System.Collections.Generic;
//using System.Web.Mvc;
//using Vidly.Models;
//using Vidly.ViewModels;

//namespace Vidly.Controllers
//{
//    public class MoviesController : Controller
//    {
//        public ViewResult Index()
//        {
//            var movies = GetMovies();

//            return View(movies);    
//        }

//        private IEnumerable<Movie> GetMovies()
//        {
//            return new List<Movie>
//            {
//                new Movie { Id = 1, Name = "Shrek" },
//                new Movie { Id = 2, Name = "Wall-e" }
//            };
//        }

//        // GET: Movies/Random
//        public ActionResult Random()
//        {
//            var movie = new Movie() { Name = "Shrek!" };
//            var customers = new List<Customer>
//            {
//                new Customer { Name = "Customer 1" },
//                new Customer { Name = "Customer 2" }
//            };

//            var viewModel = new RandomMovieViewModel
//            {
//                Movie = movie,
//                Customers = customers
//            };

//            return View(viewModel);
//        }
//    }
//}
