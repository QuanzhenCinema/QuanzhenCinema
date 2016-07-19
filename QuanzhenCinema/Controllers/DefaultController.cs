using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanzhenCinema.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult developer()
        {
            return View();
        }
        public ActionResult description()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
    }
}