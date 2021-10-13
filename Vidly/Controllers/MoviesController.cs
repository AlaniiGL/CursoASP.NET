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
            var movies = _context1.Movies.Include(m => m.Genres).ToList();
            return View(movies);
        }

        public ViewResult New()
        {
            var genres = _context1.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MoviesForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context1.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context1.Genres.ToList()
            };

            return View("MoviesForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var movies = _context1.Movies.Include(m => m.Genres).SingleOrDefault(m => m.Id == id);
            return View(movies);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context1.Movies.Add(movie);
            }

            else
            {
                var movieInDb = _context1.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenresId = movie.GenresId;
                movieInDb.Stock = movie.Stock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context1.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

    }
}