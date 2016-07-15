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
    public class ORDERsController : Controller
    {
        private Quanzhen db = new Quanzhen();

        // GET: ORDERs
        public ActionResult Index()
        {
            var oRDER = db.ORDER.Include(o => o.STAFF);
            return View(oRDER.ToList());
        }

        // GET: ORDERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER oRDER = db.ORDER.Find(id);
            if (oRDER == null)
            {
                return HttpNotFound();
            }
            return View(oRDER);
        }

        // GET: ORDERs/Create
        public ActionResult Create()
        {
            ViewBag.OPERATOR_ID = new SelectList(db.STAFF, "ID", "PASSWORD");
            return View();
        }

        // POST: ORDERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ORDER_ID,OPERATOR_ID,PHONE_NUMBER")] ORDER oRDER)
        {
            if (ModelState.IsValid)
            {
                db.ORDER.Add(oRDER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OPERATOR_ID = new SelectList(db.STAFF, "ID", "PASSWORD", oRDER.OPERATOR_ID);
            return View(oRDER);
        }

        // GET: ORDERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER oRDER = db.ORDER.Find(id);
            if (oRDER == null)
            {
                return HttpNotFound();
            }
            ViewBag.OPERATOR_ID = new SelectList(db.STAFF, "ID", "PASSWORD", oRDER.OPERATOR_ID);
            return View(oRDER);
        }

        // POST: ORDERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ORDER_ID,OPERATOR_ID,PHONE_NUMBER")] ORDER oRDER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oRDER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OPERATOR_ID = new SelectList(db.STAFF, "ID", "PASSWORD", oRDER.OPERATOR_ID);
            return View(oRDER);
        }

        // GET: ORDERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER oRDER = db.ORDER.Find(id);
            if (oRDER == null)
            {
                return HttpNotFound();
            }
            return View(oRDER);
        }

        // POST: ORDERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ORDER oRDER = db.ORDER.Find(id);
            db.ORDER.Remove(oRDER);
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
