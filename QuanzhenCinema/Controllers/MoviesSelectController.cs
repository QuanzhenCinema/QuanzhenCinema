using QuanzhenCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace QuanzhenCinema.Controllers
{
    [BasicAuth]
    public class MoviesSelectController : Controller
    {
        Quanzhen db = new Quanzhen();

        public ActionResult Index(string searchString, string id)
        {
            string sortOrder = id;
            IEnumerable<MOVIE> movies = db.MOVIE;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = db.MOVIE.Where(s => s.NAME.Contains(searchString));
                movies = movies.OrderBy(s => s.NAME);
            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "NAME_desc" : "";
            ViewBag.DateSortParm = sortOrder == "DATE" ? "DATE_desc" : "DATE";

            var movie = from s in db.MOVIE
                        select s;

            switch (sortOrder)
            {
                case "NAME_desc":
                    movies = movies.OrderByDescending(s => s.NAME);
                    break;
                case "DATE":
                    movies = movies.OrderBy(s => s.EXPIRE_DATE);
                    break;
                case "DATE_desc":
                    movies = movies.OrderByDescending(s => s.EXPIRE_DATE);
                    break;
                default:
                    movies = movies.OrderBy(s => s.NAME);
                    break;
            }

            return View(movies);
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            string sortOrder = "";
            IEnumerable<MOVIE> movies = db.MOVIE;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = db.MOVIE.Where(s => s.NAME.Contains(searchString));
                movies = movies.OrderBy(s => s.NAME);
            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "NAME_desc" : "";
            ViewBag.DateSortParm = sortOrder == "DATE" ? "DATE_desc" : "DATE";

            var movie = from s in db.MOVIE
                        select s;

            switch (sortOrder)
            {
                case "NAME_desc":
                    movies = movies.OrderByDescending(s => s.NAME);
                    break;
                case "DATE":
                    movies = movies.OrderBy(s => s.EXPIRE_DATE);
                    break;
                case "DATE_desc":
                    movies = movies.OrderByDescending(s => s.EXPIRE_DATE);
                    break;
                default:
                    movies = movies.OrderBy(s => s.NAME);
                    break;
            }
            ViewBag.movies = movies.ToList();
            //       movies.ToList()[0].
            return View(movies);
        }
    }
}