using System;
using System.Web.Mvc;
using QuanzhenCinema.Models;
using System.Web.Script.Serialization;


namespace QuanzhenCinema.Controllers
{
    public class Schedule_MovieController : Controller
    {
        Quanzhen db = new Quanzhen();

        // GET: Schedule_Movie
        public ActionResult getInfo(int Year, int Month, int Day){
            DateTime d = new DateTime(Year, Month, Day);

            Business.Schedule_Movie t = new Business.Schedule_Movie(d);
            Business.Package pkg = new Business.Package(t);
            ViewBag.pkg = pkg;

            var json = new JavaScriptSerializer().Serialize(ViewBag.pkg);
            ViewBag.json = json;
            return View(ViewBag);
        }

        public ActionResult AddUpdate()
        {
            //   ViewBag.DISPLAY_ID = new SelectList(db.DISPLAY, "DISPLAY_ID", "DISPLAY_ID");
            //   ViewBag.HALL_ID = new SelectList(db.HALL, "HALL_ID", "HALL_ID");
            return View();
        }


        [HttpPost]
        public ActionResult AddUpdate([Bind(Include = "SCHEDULE_ID,DISPLAY_ID,START_TIME,END_TIME,HALL_ID,ORIGINAL_PRICE,START_SLOT,END_SLOT")] SCHEDULE sCHEDULE)
        {
    //        if (ModelState.IsValid)
     //       {
                SCHEDULE s = db.SCHEDULE.Find(sCHEDULE.SCHEDULE_ID);
                if (s == null)
                {
                sCHEDULE.SCHEDULE_ID = 0;
                    db.SCHEDULE.Add(sCHEDULE);
                    db.SaveChanges();
                }
                else
                {
                    db.SCHEDULE.Remove(s);
                    db.SaveChanges();
                    db.SCHEDULE.Add(sCHEDULE);
                    db.SaveChanges();
                }
     //       }

            //   ViewBag.IsSussessful=
            return View(sCHEDULE);
        }
    }

}
