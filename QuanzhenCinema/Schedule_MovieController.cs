using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModel;
using WebApplication1.Business;

namespace WebApplication1.Controllers
{
    public class Schedule_MovieController : Controller
    {
        // GET: Schedule_Movie
        public ActionResult Index(){
            WebApplication1.Business.Schedule_Movie s = new WebApplication1.Business.Schedule_Movie();

            ViewBag.display = s.Display();
            ViewBag.movie_name = s.m_name();
            ViewBag.hall = s.Hall();
            return View(ViewBag);
        }
    }
}