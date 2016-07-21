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
    [BasicAuth]
    public class DISPLAYsController : Controller
    {
        private Quanzhen db = new Quanzhen();

        // GET: DISPLAYs
        public ActionResult Index()
        {
            var dISPLAY = db.DISPLAY.Include(d => d.MOVIE);
            return View(dISPLAY.ToList());
        }

        // GET: DISPLAYs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISPLAY dISPLAY = db.DISPLAY.Find(id);
            if (dISPLAY == null)
            {
                return HttpNotFound();
            }
            return View(dISPLAY);
        }

        // GET: DISPLAYs/Create
        public ActionResult Create()
        {
            ViewBag.MOVIE_ID = new SelectList(db.MOVIE, "MOVIE_ID", "NAME");
            return View();
        }

        // POST: DISPLAYs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DISPLAY_ID,MOVIE_ID,IS_3D,IS_IMAX,LANGUAGE,LOWEST_PRICE,LENGTH")] DISPLAY dISPLAY)
        {
            if (ModelState.IsValid)
            {
                db.DISPLAY.Add(dISPLAY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MOVIE_ID = new SelectList(db.MOVIE, "MOVIE_ID", "NAME", dISPLAY.MOVIE_ID);
            return View(dISPLAY);
        }

        // GET: DISPLAYs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISPLAY dISPLAY = db.DISPLAY.Find(id);
            if (dISPLAY == null)
            {
                return HttpNotFound();
            }
            ViewBag.MOVIE_ID = new SelectList(db.MOVIE, "MOVIE_ID", "NAME", dISPLAY.MOVIE_ID);
            return View(dISPLAY);
        }

        // POST: DISPLAYs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DISPLAY_ID,MOVIE_ID,IS_3D,IS_IMAX,LANGUAGE,LOWEST_PRICE,LENGTH")] DISPLAY dISPLAY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dISPLAY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MOVIE_ID = new SelectList(db.MOVIE, "MOVIE_ID", "NAME", dISPLAY.MOVIE_ID);
            return View(dISPLAY);
        }

        // GET: DISPLAYs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISPLAY dISPLAY = db.DISPLAY.Find(id);
            if (dISPLAY == null)
            {
                return HttpNotFound();
            }
            return View(dISPLAY);
        }

        // POST: DISPLAYs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DISPLAY dISPLAY = db.DISPLAY.Find(id);
            db.DISPLAY.Remove(dISPLAY);
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
