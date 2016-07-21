using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using QuanzhenCinema.Models;

namespace QuanzhenCinema.Controllers
{
    [BasicAuth]
    public class MEMBERsController : Controller
    {
        private Quanzhen db = new Quanzhen();

        // GET: MEMBERs
        [BasicAuth]
        public ActionResult Index()
        {
            return View(db.MEMBER.ToList());
        }

        // GET: MEMBERs/Details/5
        [BasicAuth]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBER mEMBER = db.MEMBER.Find(id);
            if (mEMBER == null)
            {
                return HttpNotFound();
            }
            return View(mEMBER);
        }

        // GET: MEMBERs/Create
        [BasicAuth]
        public ActionResult Create()
        {
            return View();
        }

        // POST: MEMBERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [BasicAuth]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PHONE_NUMBER,NAME,REGISTER_DATE,REMAINING_DAY,CREDIT")] MEMBER mEMBER)
        {
            if (ModelState.IsValid)
            {
                db.MEMBER.Add(mEMBER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mEMBER);
        }

        // GET: MEMBERs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBER mEMBER = db.MEMBER.Find(id);
            if (mEMBER == null)
            {
                return HttpNotFound();
            }
            return View(mEMBER);
        }

        // POST: MEMBERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [BasicAuth]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PHONE_NUMBER,NAME,REGISTER_DATE,REMAINING_DAY,CREDIT")] MEMBER mEMBER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mEMBER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mEMBER);
        }

        // GET: MEMBERs/Delete/5
        [BasicAuth]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBER mEMBER = db.MEMBER.Find(id);
            if (mEMBER == null)
            {
                return HttpNotFound();
            }
            return View(mEMBER);
        }

        // POST: MEMBERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MEMBER mEMBER = db.MEMBER.Find(id);
            db.MEMBER.Remove(mEMBER);
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
