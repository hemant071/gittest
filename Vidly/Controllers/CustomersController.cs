using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;
using System.Runtime.Caching;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context; //for accessing the database

        public CustomersController()
        {
            //intializing _context in constructor
            _context = new ApplicationDbContext();
            //after this we need to dispose this by override

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

      

        public ViewResult Index()
        {
            //Authencation and Authorization
            if (User.IsInRole(RoleName.CanManageMovies))

            {

                return View("CList");
            }

            return View("ReadOnlyCList");

            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();


            ////Data Caching

            //if (MemoryCache.Default["Genres"] == null)
            //{
            //    MemoryCache.Default["Genres"] = _context.Genre.ToList();
            //}
            //var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;

            //return View();


        }


        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

         

            return View(customer);
        }

        public ActionResult CustomerForm()
        {
           

            var MembershipType = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer=new Customer(),
                MembershipTypes = MembershipType

            };
            return View("CustomerForm",viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipType.ToList()
                };



                return View("CustomerForm",viewmodel);
            }

            if(customer.Id==0)
            _context.Customers.Add(customer);
            else
            {
                var CustomerDB = _context.Customers.FirstOrDefault(c => c.Id == customer.Id);

                CustomerDB.Name = customer.Name;
                CustomerDB.Birthdate = customer.Birthdate;
                customer.MembershipTypeId = customer.MembershipTypeId;
                customer.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");

        }

        public ActionResult Edit(int id)
        {
            var customers = _context.Customers.FirstOrDefault(c => c.Id == id);

            if (customers == null)
                return HttpNotFound();

            var Viewmodel = new CustomerFormViewModel

            {
                Customer = customers,
                MembershipTypes = _context.MembershipType.ToList(),

            };


            return View("CustomerForm",Viewmodel);
        }

       
    }
}