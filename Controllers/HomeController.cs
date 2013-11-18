using Homework5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework5.Controllers
{

    public class HomeController : Controller
    {
        private MoviesDb db = new MoviesDb(string searchTerm=null);

        public ActionResult Index()
        {
            var m = db.Movies
              .Where(m => searchTerm == null || m.Title.StartsWith(searchTerm))
              .Take(30)
              .OrderBy(m => m.Title)
              .Select(
                  m => new MovieViewModel
                  {
                      Id = m.Id,
                      Title = m.Title,
                      C = b.Color,
                      MaxCalories = b.MaxCalories,


                  });

            return View(m);
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
    }
}
