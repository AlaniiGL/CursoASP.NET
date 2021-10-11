using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random

        private ApplicationDbContext _context1;

        public MoviesController()
        {
            _context1 = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context1.Dispose();
        }

        public ViewResult Index()
        {
            var movies = _context1.Movies.Include(m => m.NameGenre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movies = _context1.Movies.Include(m => m.NameGenre).SingleOrDefault(m => m.Id == id);
            return View(movies);
        }

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            var customers = new List<Customer>
            {
                new Customer{Name = "Customer 1"},
                new Customer{Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

    }
}