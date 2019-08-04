using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class HawaController : Controller
    {
        private ApplicationDbContext _context; //for accessing the database

        public HawaController()
        {
            //intializing _context in constructor
            _context = new ApplicationDbContext();
            //after this we need to dispose this by override

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        // GET: Hawa
        public ActionResult Index(Movies movie)
        {
            // var customer = _context.Customers.FirstOrDefault();
            
           
            var genre = _context.Genre.ToList();
            var viemodel = new AllFormViewModel
            {
                Movie = movie,
                Genre = genre

            };
            return View (viemodel);
           
        }
    }
}