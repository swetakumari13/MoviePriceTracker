using MoviePriceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MoviePriceTracker.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult GetSortedMoviesByPrice(string dataProvider)
        {
            DataManager Manager = new DataManager();
            MoviesModel MoviesData = Manager.GetSortedMoviesByPrice(dataProvider);
            return Json(MoviesData, JsonRequestBehavior.AllowGet);
        }
    }
}