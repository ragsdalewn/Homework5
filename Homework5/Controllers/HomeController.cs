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
        private MoviesDb _db = new MoviesDb();
     
        public ActionResult Index()
        {
            var v = _db.Movies
                .Select(m => new MovieViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    LengthInMinutes = m.LengthInMinutes,
                    Year = m.Year,
                    NumTags = m.Tags.Count(),
                    IMDBurl = m.IMDBurl,
                    Format = m.Format
                });

            return View(v);
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
