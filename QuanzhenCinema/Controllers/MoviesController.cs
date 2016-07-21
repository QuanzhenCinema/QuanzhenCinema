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
    public class MoviesController : Controller
    {
        private Quanzhen db = new Quanzhen();

        // GET: Movies
        public ActionResult Index()
        {
            return View(db.MOVIE.ToList());
        }

        [HttpPost]
        public ActionResult Index(String str)
        {
            String sql = "select * from movie where name like '%" + str + "%'";
            List<MOVIE> movie = db.Database.SqlQuery<MOVIE>(sql).ToList();
            ViewBag.movie = movie;
            return View(ViewBag);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIE mOVIE = db.MOVIE.Find(id);
            if (mOVIE == null)
            {
                return HttpNotFound();
            }
            return View(mOVIE);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MOVIE_ID,NAME,DESCRIPTION,EXPIRE_DATE")] MOVIE mOVIE)
        {
            if (ModelState.IsValid)
            {
                db.MOVIE.Add(mOVIE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mOVIE);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIE mOVIE = db.MOVIE.Find(id);
            if (mOVIE == null)
            {
                return HttpNotFound();
            }
            return View(mOVIE);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MOVIE_ID,NAME,DESCRIPTION,EXPIRE_DATE")] MOVIE mOVIE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mOVIE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mOVIE);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIE mOVIE = db.MOVIE.Find(id);
            if (mOVIE == null)
            {
                return HttpNotFound();
            }
            return View(mOVIE);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MOVIE mOVIE = db.MOVIE.Find(id);
            db.MOVIE.Remove(mOVIE);
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
