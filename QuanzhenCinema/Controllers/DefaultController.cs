using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using QuanzhenCinema.Business;

namespace QuanzhenCinema.Controllers
{
    [BasicAuth]
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult developer()
        {
            return View();
        }

        public ActionResult description(int id)
        {//电影信息 图片 以及三天排片display
            MovieDetail md=new MovieDetail(id);
            ViewBag.moviedetail = md.getMovieDetails();
            ViewBag.categories = md.getCategory();
            ViewBag.length = md.getLength();
            ViewBag.schedule1 = md.getSchedule1();
            ViewBag.schedule2 = md.getSchedule2();
            ViewBag.schedule3 = md.getSchedule3();
            var json = new JavaScriptSerializer().Serialize(ViewBag.schedule3);
            ViewBag.json = json;
            return View(ViewBag);
        }

        public ActionResult login()
        {
            return View();
        }
    }
}