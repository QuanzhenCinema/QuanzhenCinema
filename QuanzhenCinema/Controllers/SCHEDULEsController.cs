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
    public class SCHEDULEsController : Controller
    {
        private Quanzhen db = new Quanzhen();

        // GET: SCHEDULEs
        public ActionResult Index()
        {
            var sCHEDULE = db.SCHEDULE.Include(s => s.DISPLAY).Include(s => s.HALL);
            return View(sCHEDULE.ToList());
        }

        // GET: SCHEDULEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCHEDULE sCHEDULE = db.SCHEDULE.Find(id);
            if (sCHEDULE == null)
            {
                return HttpNotFound();
            }
            return View(sCHEDULE);
        }

        // GET: SCHEDULEs/Create
        public ActionResult Create()
        {
            ViewBag.DISPLAY_ID = new SelectList(db.DISPLAY, "DISPLAY_ID", "LANGUAGE");
            ViewBag.HALL_ID = new SelectList(db.HALL, "HALL_ID", "HALL_ID");
            return View();
        }

        // POST: SCHEDULEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SCHEDULE_ID,DISPLAY_ID,START_TIME,END_TIME,DAY,HALL_ID,ORIGINAL_PRICE")] SCHEDULE sCHEDULE)
        {
            if (ModelState.IsValid)
            {
                db.SCHEDULE.Add(sCHEDULE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DISPLAY_ID = new SelectList(db.DISPLAY, "DISPLAY_ID", "LANGUAGE", sCHEDULE.DISPLAY_ID);
            ViewBag.HALL_ID = new SelectList(db.HALL, "HALL_ID", "HALL_ID", sCHEDULE.HALL_ID);
            return View(sCHEDULE);
        }

        // GET: SCHEDULEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCHEDULE sCHEDULE = db.SCHEDULE.Find(id);
            if (sCHEDULE == null)
            {
                return HttpNotFound();
            }
            ViewBag.DISPLAY_ID = new SelectList(db.DISPLAY, "DISPLAY_ID", "LANGUAGE", sCHEDULE.DISPLAY_ID);
            ViewBag.HALL_ID = new SelectList(db.HALL, "HALL_ID", "HALL_ID", sCHEDULE.HALL_ID);
            return View(sCHEDULE);
        }

        // POST: SCHEDULEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SCHEDULE_ID,DISPLAY_ID,START_TIME,END_TIME,DAY,HALL_ID,ORIGINAL_PRICE")] SCHEDULE sCHEDULE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sCHEDULE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DISPLAY_ID = new SelectList(db.DISPLAY, "DISPLAY_ID", "LANGUAGE", sCHEDULE.DISPLAY_ID);
            ViewBag.HALL_ID = new SelectList(db.HALL, "HALL_ID", "HALL_ID", sCHEDULE.HALL_ID);
            return View(sCHEDULE);
        }

        // GET: SCHEDULEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCHEDULE sCHEDULE = db.SCHEDULE.Find(id);
            if (sCHEDULE == null)
            {
                return HttpNotFound();
            }
            return View(sCHEDULE);
        }

        // POST: SCHEDULEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SCHEDULE sCHEDULE = db.SCHEDULE.Find(id);
            db.SCHEDULE.Remove(sCHEDULE);
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
