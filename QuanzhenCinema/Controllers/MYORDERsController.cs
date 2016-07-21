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
    public class MYORDERsController : Controller
    {
        private Quanzhen db = new Quanzhen();

        // GET: MYORDERs
        public ActionResult Index()
        {
            var mYORDER = db.MYORDER.Include(m => m.STAFF);
            return View(mYORDER.ToList());
        }

        // GET: MYORDERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MYORDER mYORDER = db.MYORDER.Find(id);
            if (mYORDER == null)
            {
                return HttpNotFound();
            }
            return View(mYORDER);
        }

        // GET: MYORDERs/Create
        public ActionResult Create()
        {
            ViewBag.OPERATOR_ID = new SelectList(db.STAFF, "ID", "PASSWORD");
            return View();
        }

        // POST: MYORDERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ORDER_ID,OPERATOR_ID,PHONE_NUMBER")] MYORDER mYORDER)
        {
            if (ModelState.IsValid)
            {
                db.MYORDER.Add(mYORDER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OPERATOR_ID = new SelectList(db.STAFF, "ID", "PASSWORD", mYORDER.OPERATOR_ID);
            return View(mYORDER);
        }

        // GET: MYORDERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MYORDER mYORDER = db.MYORDER.Find(id);
            if (mYORDER == null)
            {
                return HttpNotFound();
            }
            ViewBag.OPERATOR_ID = new SelectList(db.STAFF, "ID", "PASSWORD", mYORDER.OPERATOR_ID);
            return View(mYORDER);
        }

        // POST: MYORDERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ORDER_ID,OPERATOR_ID,PHONE_NUMBER")] MYORDER mYORDER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mYORDER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OPERATOR_ID = new SelectList(db.STAFF, "ID", "PASSWORD", mYORDER.OPERATOR_ID);
            return View(mYORDER);
        }

        // GET: MYORDERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MYORDER mYORDER = db.MYORDER.Find(id);
            if (mYORDER == null)
            {
                return HttpNotFound();
            }
            return View(mYORDER);
        }

        // POST: MYORDERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MYORDER mYORDER = db.MYORDER.Find(id);
            db.MYORDER.Remove(mYORDER);
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
