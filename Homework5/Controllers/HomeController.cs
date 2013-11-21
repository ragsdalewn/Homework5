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

        public ActionResult Index(string searchTerm = null)
        {
            var v = _db.Movies
                .Where(m => searchTerm == null || m.Title.StartsWith(searchTerm))
                .Take(30)
                .OrderBy(m => m.Title)
                .Select(m => new MovieViewModel

                {
                    Id = m.Id,
                    Title = m.Title,
                    LengthInMinutes = m.LengthInMinutes,
                    Year = m.Year,
                    NumTags = m.Tags.Count(),
                    IMDBurl = m.IMDBurl,
                    Format = (FormatEnum)m.Format,
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
            return View(new MovieViewModel { });
        }

        [HttpPost]
        public ActionResult Create(MovieViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Movie movie = new Movie();
                movie.Title = viewModel.Title;
                movie.Year = viewModel.Year;
                movie.LengthInMinutes = viewModel.LengthInMinutes;
                movie.IMDBurl = viewModel.IMDBurl;
                movie.Format = Convert.ToInt32(viewModel.Format);
               
                _db.Movies.Add(movie);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        public ActionResult Edit(int id = 0)
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

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }
        
        [HttpPost]
        public ActionResult Edit(MovieViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Movie movie = _db.Movies.Where(m => m.Id == viewModel.Id).FirstOrDefault();
                movie.Title = viewModel.Title;
                movie.Year = viewModel.Year;
                movie.LengthInMinutes = viewModel.LengthInMinutes;
                movie.IMDBurl = viewModel.IMDBurl;
                movie.Format = Convert.ToInt32(viewModel.Format);
                 
                _db.Entry(movie).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(viewModel);
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
                        Format = (FormatEnum)m.Format,
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
                    }),
                    NumTags = _db.Tags
                    .Where(t => t.MovieId == m.Id).Count()

                }).FirstOrDefault();

            if (movie == null)
            {
                return HttpNotFound();
            }
               
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
           
            TagViewModel viewModel = _db.Tags
                    .Where(t => t.Id == id)
                    .Select(t => new TagViewModel
                    {
                        Id = t.Id,
                        Date = t.Date,
                        MovieTag = t.MovieTag,
                        MovieId = t.MovieId,
                      
                    }).FirstOrDefault();

            String movieTitle = _db.Movies.Find(viewModel.MovieId).Title;
            viewModel.MovieTitle = movieTitle;

            return View(viewModel);

        }

        [HttpPost]
        public ActionResult EditTag(TagViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
               Tag tag = _db.Tags.Where(t => t.Id == viewModel.Id).FirstOrDefault();
               tag.MovieTag = viewModel.MovieTag;
               tag.Date = DateTime.Now;
               _db.Entry(tag).State = EntityState.Modified;
               _db.SaveChanges();

               return RedirectToAction("Tags", new { id = viewModel.MovieId });
            }

            return View(viewModel);
        }

     public ActionResult TagDelete(int id = 0)
        {
               TagViewModel tagView = _db.Tags
                    .Where(t => t.Id == id)
                    .Select(t => new TagViewModel
                    {
                        Id = t.Id,
                        Date = t.Date,
                        MovieTag = t.MovieTag,
                        MovieId = t.MovieId,

                    }).FirstOrDefault();

               String movieTitle = _db.Movies.Find(tagView.MovieId).Title;
               tagView.MovieTitle = movieTitle;
         
            if (tagView == null)
            {
                return HttpNotFound();
            }

            return View(tagView);
        }


        [HttpPost, ActionName("Delete Tag")]
        public ActionResult TagDeleteConfirmed(int id)
        {
            Tag tag = _db.Tags.Find(id);
			int MovieId = tag.MovieId;
            _db.Tags.Remove(tag);
            _db.SaveChanges();
            return RedirectToAction("Tags", new { id = MovieId });
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
