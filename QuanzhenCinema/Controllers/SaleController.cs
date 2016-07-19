using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanzhenCinema.Models;
using System.Web.Script.Serialization;

namespace QuanzhenCinema.Controllers{
    public class SaleController : Controller{
        Quanzhen db = new Quanzhen();

        // GET: Sale
        public ActionResult Index(){
            return View();
        }

        public String getMovies(int year,int month,int day){
            DateTime dt = new DateTime(year, month, day);
            Business.Sale s = new Business.Sale(dt);
            ViewBag.movie = s.getMovies();

            var json = new JavaScriptSerializer().Serialize(ViewBag.movie);
            return json;
        }
        
        public String getSchedules(int year, int month, int day,int Movie_id){
            DateTime dt = new DateTime(year, month, day);
            Business.Sale s = new Business.Sale(dt,Movie_id);
            ViewBag.schedule = s.getSchedules();

            var json = new JavaScriptSerializer().Serialize(ViewBag.schedule);
            return json;
        }

        public String getSeats(int id){
            Business.Sale s = new Business.Sale(id);
            ViewBag.seats = s.getSeats();

            var json = new JavaScriptSerializer().Serialize(ViewBag.seats);
            return json;
        }

        [HttpPost]
        public ActionResult Ticket([Bind(Include = "TICKET_ID,SCHEDULE_ID,PRICE,ORDER_ID,SEAT_COLUMN_ID,SEAT_ROW_ID,SEAT_HALL_ID")] TICKET tICKET){
            if (ModelState.IsValid){
                db.TICKET.Add(tICKET);
                db.SaveChanges();
            }

            return View(tICKET);
        }

    }
}