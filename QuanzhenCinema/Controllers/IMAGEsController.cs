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
    public class IMAGEsController : Controller
    {
        private Quanzhen db = new Quanzhen();

        // GET: IMAGEs
        public ActionResult Index()
        {
            var iMAGE = db.IMAGE.Include(i => i.MOVIE);
            return View(iMAGE.ToList());
        }

        // GET: IMAGEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMAGE iMAGE = db.IMAGE.Find(id);
            if (iMAGE == null)
            {
                return HttpNotFound();
            }
            return View(iMAGE);
        }

        // GET: IMAGEs/Create
        public ActionResult Create()
        {
            ViewBag.MOVIE_ID = new SelectList(db.MOVIE, "MOVIE_ID", "NAME");
            return View();
        }

        // POST: IMAGEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IMAGE_ID,IMAGE_PATH,WIDTH,HEIGHT,MOVIE_ID")] IMAGE iMAGE)
        {
            if (ModelState.IsValid)
            {
                db.IMAGE.Add(iMAGE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MOVIE_ID = new SelectList(db.MOVIE, "MOVIE_ID", "NAME", iMAGE.MOVIE_ID);
            return View(iMAGE);
        }

        // GET: IMAGEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMAGE iMAGE = db.IMAGE.Find(id);
            if (iMAGE == null)
            {
                return HttpNotFound();
            }
            ViewBag.MOVIE_ID = new SelectList(db.MOVIE, "MOVIE_ID", "NAME", iMAGE.MOVIE_ID);
            return View(iMAGE);
        }

        // POST: IMAGEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IMAGE_ID,IMAGE_PATH,WIDTH,HEIGHT,MOVIE_ID")] IMAGE iMAGE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iMAGE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MOVIE_ID = new SelectList(db.MOVIE, "MOVIE_ID", "NAME", iMAGE.MOVIE_ID);
            return View(iMAGE);
        }

        // GET: IMAGEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMAGE iMAGE = db.IMAGE.Find(id);
            if (iMAGE == null)
            {
                return HttpNotFound();
            }
            return View(iMAGE);
        }

        // POST: IMAGEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IMAGE iMAGE = db.IMAGE.Find(id);
            db.IMAGE.Remove(iMAGE);
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
