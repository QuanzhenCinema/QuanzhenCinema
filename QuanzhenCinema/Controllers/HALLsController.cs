using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanzhenCinema.Models;

namespace QuanzhenCinema.Controllers
{
    public class HALLsController : Controller
    {
        private Quanzhen db = new Quanzhen();

        // GET: HALLs
        public ActionResult Index()
        {
            return View(db.HALL.ToList());
        }

        // GET: HALLs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HALL hALL = db.HALL.Find(id);
            if (hALL == null)
            {
                return HttpNotFound();
            }
            return View(hALL);
        }

        // GET: HALLs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HALLs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HALL_ID,CAPACITY,IS_3D,IS_DOLAB,IS_IMAX")] HALL hALL)
        {
            if (ModelState.IsValid)
            {
                db.HALL.Add(hALL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hALL);
        }

        // GET: HALLs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HALL hALL = db.HALL.Find(id);
            if (hALL == null)
            {
                return HttpNotFound();
            }
            return View(hALL);
        }

        // POST: HALLs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HALL_ID,CAPACITY,IS_3D,IS_DOLAB,IS_IMAX")] HALL hALL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hALL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hALL);
        }

        // GET: HALLs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HALL hALL = db.HALL.Find(id);
            if (hALL == null)
            {
                return HttpNotFound();
            }
            return View(hALL);
        }

        // POST: HALLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HALL hALL = db.HALL.Find(id);
            db.HALL.Remove(hALL);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
