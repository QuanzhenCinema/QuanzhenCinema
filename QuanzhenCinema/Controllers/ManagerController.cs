using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanzhenCinema.Business;
using QuanzhenCinema.Models;

namespace QuanzhenCinema.Controllers
{
    [BasicAuth]
    public class ManagerController : Controller
    {
        //private Quanzhen db;
        // GET: Manager
        [BasicAuth]
        public ActionResult index()
        {
            //db=new Quanzhen();
            Business.Management m = new Management();
            ViewBag.movie_count = m.getMovieCount();
            ViewBag.discount_count = m.getDiscountCount();
            ViewBag.staff_count = m.getStaffCount();
            ViewBag.member_count = m.getMemberCount();
            ViewBag.ticket_rate = m.getBarChartInfo();
            ViewBag.date_rate = m.getLineChartInfo("惊天魔盗团2");
            ViewBag.source_rate = m.getPieChartInfo();
            ViewBag.total_ticket = m.getChartInfo();
            return View(ViewBag);
        }

        //public ActionResult staff()
        //{
        //    return View();
        //}
        //public ActionResult snack()
        //{
        //    return View();
        //}
        //public ActionResult member()
        //{
        //    return View();
        //}
        //public ActionResult logout()
        //{
        //    return View();
        //}
    }
}