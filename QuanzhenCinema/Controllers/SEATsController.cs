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
    public class SEATsController : Controller
    {
        private Quanzhen db = new Quanzhen();

        // GET: SEATs
        public ActionResult Index()
        {
            var sEAT = db.SEAT.Include(s => s.HALL);
            return View(sEAT.ToList());
        }

        // GET: SEATs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEAT sEAT = db.SEAT.Find(id);
            if (sEAT == null)
            {
                return HttpNotFound();
            }
            return View(sEAT);
        }

        // GET: SEATs/Create
        public ActionResult Create()
        {
            ViewBag.HALL_ID = new SelectList(db.HALL, "HALL_ID", "HALL_ID");
            return View();
        }

        // POST: SEATs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COLUMN_ID,ROW_ID,HALL_ID")] SEAT sEAT)
        {
            if (ModelState.IsValid)
            {
                db.SEAT.Add(sEAT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HALL_ID = new SelectList(db.HALL, "HALL_ID", "HALL_ID", sEAT.HALL_ID);
            return View(sEAT);
        }

        // GET: SEATs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEAT sEAT = db.SEAT.Find(id);
            if (sEAT == null)
            {
                return HttpNotFound();
            }
            ViewBag.HALL_ID = new SelectList(db.HALL, "HALL_ID", "HALL_ID", sEAT.HALL_ID);
            return View(sEAT);
        }

        // POST: SEATs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COLUMN_ID,ROW_ID,HALL_ID")] SEAT sEAT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sEAT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HALL_ID = new SelectList(db.HALL, "HALL_ID", "HALL_ID", sEAT.HALL_ID);
            return View(sEAT);
        }

        // GET: SEATs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEAT sEAT = db.SEAT.Find(id);
            if (sEAT == null)
            {
                return HttpNotFound();
            }
            return View(sEAT);
        }

        // POST: SEATs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SEAT sEAT = db.SEAT.Find(id);
            db.SEAT.Remove(sEAT);
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
