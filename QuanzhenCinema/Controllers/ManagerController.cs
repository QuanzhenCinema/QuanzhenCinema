using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanzhenCinema.Business;
using QuanzhenCinema.Models;

namespace QuanzhenCinema.Controllers
{
    public class ManagerController : Controller
    {
        private Quanzhen db;
        // GET: Manager
        [BasicAuth]
        public ActionResult index(){
            db=new Quanzhen();
            Business.Management m=new Management();
            ViewBag.movie_count = m.getMovieCount();
            ViewBag.discount_count = m.getDiscountCount();
            ViewBag.staff_count = m.getStaffCount();
            ViewBag.member_count = m.getMemberCount();
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