using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Newtonsoft.Json.Schema;
using Proekt.Models;

namespace Proekt.Controllers
{
    public class MuseumsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Museums
        public ActionResult Index()
        {
            return View(db.Museums.ToList());
        }

        // GET: Museums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Museum museum = db.Museums.Find(id);
            if (museum == null)
            {
                return HttpNotFound();
            }
            return View(museum);
        }
        [Authorize]
        public ActionResult Confirm(int? id)
        {
            if (id == null||id.Value<1)
            {
                return View("Error");
            }
            List<Museum> museums = db.Museums.ToList();
            return View("Index",museums);
        }
        [Authorize]
        public ActionResult Purchase(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Museum museum = db.Museums.Find(id);
            if (museum == null)
            {
                return HttpNotFound();
            }
            return View(museum);
        }
        // GET: Museums/Create
        [Authorize(Roles ="Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Museums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MusesumId,Name,Price,Contact,WorkTime")] Museum museum)
        {
            if (ModelState.IsValid)
            {
                db.Museums.Add(museum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(museum);
        }

        // GET: Museums/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Museum museum = db.Museums.Find(id);
            if (museum == null)
            {
                return HttpNotFound();
            }
            return View(museum);
        }

        // POST: Museums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MusesumId,Name,Price,Contact,WorkTime")] Museum museum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(museum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(museum);
        }

        // GET: Museums/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Museum museum = db.Museums.Find(id);
            if (museum == null)
            {
                return HttpNotFound();
            }
            return View(museum);
        }

        // POST: Museums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Museum museum = db.Museums.Find(id);
            db.Museums.Remove(museum);
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
