using Homework5.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework5.Controllers
{
    public class HomeController : Controller
    {
        private MoviesDb _db = new MoviesDb();

        public ActionResult Index()
        {
            var v = _db.Movies
                .Take(30)
                .Select(m => new MovieViewModel

                {
                    Id = m.Id,
                    Title = m.Title,
                    LengthInMinutes = m.LengthInMinutes,
                    Year = m.Year,
                    NumTags = m.Tags.Count(),
                    IMDBurl = m.IMDBurl,
                    Format = m.Format,
                    Tags = _db.Tags
                            .Where(t => t.MovieId == m.Id)
                            .Select(t => new TagViewModel
                            {
                                Id = t.Id,
                                MovieId = t.MovieId,
                                Date = t.Date,
                                MovieTag = t.MovieTag
                            })
                });

            return View(v);
        }

        //Movie

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _db.Movies.Add(movie);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        public ActionResult Edit(int id = 0)
        {
            Movie movie = _db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }


        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(movie).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Details(int id)
        {

            MovieViewModel movie = _db.Movies
                    .Where(m => m.Id == id)
                    .Select(m => new MovieViewModel
                    {
                        Id = m.Id,
                        Title = m.Title,
                        LengthInMinutes = m.LengthInMinutes,
                        Year = m.Year,
                        NumTags = m.Tags.Count(),
                        IMDBurl = m.IMDBurl,
                        Format = m.Format,
                        Tags = _db.Tags
                                .Where(t => t.MovieId == m.Id)
                                .Select(t => new TagViewModel
                                {
                                    Id = t.Id,
                                    MovieId = t.MovieId,
                                    Date = t.Date,
                                    MovieTag = t.MovieTag
                                })
                    }).FirstOrDefault();

            return View(movie);
        }


        public ActionResult Delete(int id = 0)
        {
            Movie movie = _db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = _db.Movies.Find(id);
            _db.Movies.Remove(movie);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Tags

        public ActionResult Tags(int id)
        {
            MovieViewModel movie = _db.Movies
                .Where(m => m.Id == id)
                .Select(m => new MovieViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    Tags = _db.Tags
                    .Where(t => t.MovieId == m.Id)
                    .Select(t => new TagViewModel
                    {
                        Id = t.Id,
                        Date = t.Date,
                        MovieTag = t.MovieTag
                    })
                }).FirstOrDefault();

            return View(movie);
        }

        [HttpGet]
        public ActionResult CreateTag(int id)
        {
            return View(new TagViewModel { MovieId = id });
        }

        [HttpPost]
        public ActionResult CreateTag(TagViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _db.Tags.Add(new Tag { MovieId = viewModel.MovieId, Date = DateTime.Now, MovieTag = viewModel.MovieTag });
                _db.SaveChanges();

                return RedirectToAction("Tags", new { id = viewModel.MovieId });
            }

            return View("CreateTag", viewModel);
        }

        public ActionResult EditTag(int id)
        {
            Tag tag = _db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        [HttpPost]
        public ActionResult EditTag(Tag tag)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(tag).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tag);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
