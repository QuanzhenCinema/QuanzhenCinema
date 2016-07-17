using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanzhenCinema.Business;
using QuanzhenCinema.Models;
using System.Web.Script.Serialization;

namespace QuanzhenCinema.Controllers
{
    public class Schedule_MovieController : Controller
    {
        // GET: Schedule_Movie
        Quanzhen db = new Quanzhen();

        public ActionResult Index()
        {
            return View();
        }

        public String Info(int Year, int Month, int Day)
        {
            //db.Configuration.ProxyCreationEnabled = false;
            DateTime d = new DateTime(Year, Month, Day);

            Business.Schedule_Movie t = new Business.Schedule_Movie(d);
            ClassPackage cp = new ClassPackage(t);
            ViewBag.cp = cp;


            //Object ret = ViewBag;
            //Object ret = t.movie();
            var json = new JavaScriptSerializer().Serialize(ViewBag.cp);

            return json;
        }
    }
}