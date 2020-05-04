using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            if(!ModelState.IsValid) 
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genre = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie); 
            } 
            
            else 

            {
                var movieFromDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieFromDb.Name = movie.Name;
                movieFromDb.ReleaseDate = movie.ReleaseDate;
                movieFromDb.GenreId = movie.GenreId;
                movieFromDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }



/*
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            var viewModel = new RandomMovieViewModel
            {
                Movie = GetMovies().Where(m => m.Name == "Elephant Man").FirstOrDefault()
            };

            return View(viewModel);
            *//*return RedirectToAction("Index", "Home", new {page = 1, sortBoy = "name"});*//*
        }*/

        


/*        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie(){ Id = 1, Name = "Elephant Man"},
                new Movie(){ Id = 2, Name = "Twin Peaks: Fire Walk With Me"},
                new Movie(){ Id = 3, Name = "Mullholland Drv."}

            };
        }*/



        /*        public ActionResult Edit(int id)
                {
                    return Content("id=" + id);
                }

                public ActionResult Index(int? pageIndex, string sortBy)
                {
                    if(!pageIndex.HasValue)
                    {
                        pageIndex = 1;
                    }

                    if (String.IsNullOrWhiteSpace(sortBy))
                    {
                        sortBy = "Name";
                    }

                    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
                }*/


        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


/*        [Route("Movies/Details/{requestedId}")]*/
        public ActionResult Details(int id)
        {

            var Movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(mov => mov.Id == id);

            if (Movie == null)
                return HttpNotFound();

            return View(Movie);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genre = genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genre = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

    }
}