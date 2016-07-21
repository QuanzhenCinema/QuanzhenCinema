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
    public class STAFFsController : Controller
    {
        private Quanzhen db = new Quanzhen();

        // GET: STAFFs
        public ActionResult Index()
        {
            return View(db.STAFF.ToList().OrderBy(i=> i.ID));
        }

        // GET: STAFFs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STAFF sTAFF = db.STAFF.Find(id);
            if (sTAFF == null)
            {
                return HttpNotFound();
            }
            return View(sTAFF);
        }

        // GET: STAFFs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: STAFFs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PASSWORD,NAME,GENDER,POSITION")] STAFF sTAFF)
        {
            if (ModelState.IsValid)
            {
                db.STAFF.Add(sTAFF);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sTAFF);
        }

        // GET: STAFFs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STAFF sTAFF = db.STAFF.Find(id);
            if (sTAFF == null)
            {
                return HttpNotFound();
            }
            return View(sTAFF);
        }

        // POST: STAFFs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PASSWORD,NAME,GENDER,POSITION")] STAFF sTAFF)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTAFF).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sTAFF);
        }

        // GET: STAFFs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STAFF sTAFF = db.STAFF.Find(id);
            if (sTAFF == null)
            {
                return HttpNotFound();
            }
            return View(sTAFF);
        }

        // POST: STAFFs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STAFF sTAFF = db.STAFF.Find(id);
            db.STAFF.Remove(sTAFF);
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
