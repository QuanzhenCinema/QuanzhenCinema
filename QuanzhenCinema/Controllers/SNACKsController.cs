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
    public class SNACKsController : Controller
    {
        private Quanzhen db = new Quanzhen();

        // GET: SNACKs
        public ActionResult Index()
        {
            return View(db.SNACK.ToList());
        }

        // GET: SNACKs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SNACK sNACK = db.SNACK.Find(id);
            if (sNACK == null)
            {
                return HttpNotFound();
            }
            return View(sNACK);
        }

        // GET: SNACKs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SNACKs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SNACK_ID,NAME,PRICE")] SNACK sNACK)
        {
            if (ModelState.IsValid)
            {
                db.SNACK.Add(sNACK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sNACK);
        }

        // GET: SNACKs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SNACK sNACK = db.SNACK.Find(id);
            if (sNACK == null)
            {
                return HttpNotFound();
            }
            return View(sNACK);
        }

        // POST: SNACKs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SNACK_ID,NAME,PRICE")] SNACK sNACK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sNACK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sNACK);
        }

        // GET: SNACKs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SNACK sNACK = db.SNACK.Find(id);
            if (sNACK == null)
            {
                return HttpNotFound();
            }
            return View(sNACK);
        }

        // POST: SNACKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SNACK sNACK = db.SNACK.Find(id);
            db.SNACK.Remove(sNACK);
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
