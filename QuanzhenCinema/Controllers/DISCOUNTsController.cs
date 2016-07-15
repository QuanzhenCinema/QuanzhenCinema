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
    public class DISCOUNTsController : Controller
    {
        private Quanzhen db = new Quanzhen();

        // GET: DISCOUNTs
        public ActionResult Index()
        {
            return View(db.DISCOUNT.ToList());
        }

        // GET: DISCOUNTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISCOUNT dISCOUNT = db.DISCOUNT.Find(id);
            if (dISCOUNT == null)
            {
                return HttpNotFound();
            }
            return View(dISCOUNT);
        }

        // GET: DISCOUNTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DISCOUNTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DISCOUNT_ID,RATE,NUM,START_DATE,REMAINING_DAY,WEEKDAY")] DISCOUNT dISCOUNT)
        {
            if (ModelState.IsValid)
            {
                db.DISCOUNT.Add(dISCOUNT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dISCOUNT);
        }

        // GET: DISCOUNTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISCOUNT dISCOUNT = db.DISCOUNT.Find(id);
            if (dISCOUNT == null)
            {
                return HttpNotFound();
            }
            return View(dISCOUNT);
        }

        // POST: DISCOUNTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DISCOUNT_ID,RATE,NUM,START_DATE,REMAINING_DAY,WEEKDAY")] DISCOUNT dISCOUNT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dISCOUNT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dISCOUNT);
        }

        // GET: DISCOUNTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISCOUNT dISCOUNT = db.DISCOUNT.Find(id);
            if (dISCOUNT == null)
            {
                return HttpNotFound();
            }
            return View(dISCOUNT);
        }

        // POST: DISCOUNTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DISCOUNT dISCOUNT = db.DISCOUNT.Find(id);
            db.DISCOUNT.Remove(dISCOUNT);
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
