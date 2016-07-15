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
    public class TICKETsController : Controller
    {
        private Quanzhen db = new Quanzhen();

        // GET: TICKETs
        public ActionResult Index()
        {
            var tICKET = db.TICKET.Include(t => t.ORDER).Include(t => t.SCHEDULE).Include(t => t.SEAT);
            return View(tICKET.ToList());
        }

        // GET: TICKETs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKET tICKET = db.TICKET.Find(id);
            if (tICKET == null)
            {
                return HttpNotFound();
            }
            return View(tICKET);
        }

        // GET: TICKETs/Create
        public ActionResult Create()
        {
            ViewBag.ORDER_ID = new SelectList(db.ORDER, "ORDER_ID", "ORDER_ID");
            ViewBag.SCHEDULE_ID = new SelectList(db.SCHEDULE, "SCHEDULE_ID", "SCHEDULE_ID");
            ViewBag.SEAT_COLUMN_ID = new SelectList(db.SEAT, "COLUMN_ID", "COLUMN_ID");
            return View();
        }

        // POST: TICKETs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TICKET_ID,SCHEDULE_ID,PRICE,ORDER_ID,SEAT_COLUMN_ID,SEAT_ROW_ID,SEAT_HALL_ID")] TICKET tICKET)
        {
            if (ModelState.IsValid)
            {
                db.TICKET.Add(tICKET);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ORDER_ID = new SelectList(db.ORDER, "ORDER_ID", "ORDER_ID", tICKET.ORDER_ID);
            ViewBag.SCHEDULE_ID = new SelectList(db.SCHEDULE, "SCHEDULE_ID", "SCHEDULE_ID", tICKET.SCHEDULE_ID);
            ViewBag.SEAT_COLUMN_ID = new SelectList(db.SEAT, "COLUMN_ID", "COLUMN_ID", tICKET.SEAT_COLUMN_ID);
            return View(tICKET);
        }

        // GET: TICKETs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKET tICKET = db.TICKET.Find(id);
            if (tICKET == null)
            {
                return HttpNotFound();
            }
            ViewBag.ORDER_ID = new SelectList(db.ORDER, "ORDER_ID", "ORDER_ID", tICKET.ORDER_ID);
            ViewBag.SCHEDULE_ID = new SelectList(db.SCHEDULE, "SCHEDULE_ID", "SCHEDULE_ID", tICKET.SCHEDULE_ID);
            ViewBag.SEAT_COLUMN_ID = new SelectList(db.SEAT, "COLUMN_ID", "COLUMN_ID", tICKET.SEAT_COLUMN_ID);
            return View(tICKET);
        }

        // POST: TICKETs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TICKET_ID,SCHEDULE_ID,PRICE,ORDER_ID,SEAT_COLUMN_ID,SEAT_ROW_ID,SEAT_HALL_ID")] TICKET tICKET)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tICKET).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ORDER_ID = new SelectList(db.ORDER, "ORDER_ID", "ORDER_ID", tICKET.ORDER_ID);
            ViewBag.SCHEDULE_ID = new SelectList(db.SCHEDULE, "SCHEDULE_ID", "SCHEDULE_ID", tICKET.SCHEDULE_ID);
            ViewBag.SEAT_COLUMN_ID = new SelectList(db.SEAT, "COLUMN_ID", "COLUMN_ID", tICKET.SEAT_COLUMN_ID);
            return View(tICKET);
        }

        // GET: TICKETs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKET tICKET = db.TICKET.Find(id);
            if (tICKET == null)
            {
                return HttpNotFound();
            }
            return View(tICKET);
        }

        // POST: TICKETs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TICKET tICKET = db.TICKET.Find(id);
            db.TICKET.Remove(tICKET);
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
