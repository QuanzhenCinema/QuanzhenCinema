using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanzhenCinema.ViewModel;
using QuanzhenCinema.Business;

namespace QuanzhenCinema.Controllers
{
    public class Schedule_MovieController : Controller
    {
        // GET: Schedule_Movie
        public ActionResult Index(){
            QuanzhenCinema.Business.Schedule_Movie s = new QuanzhenCinema.Business.Schedule_Movie();

            ViewBag.display = s.Display();
            ViewBag.movie_name = s.m_name();
            ViewBag.hall = s.Hall();
            return View(ViewBag);
        }
    }
}