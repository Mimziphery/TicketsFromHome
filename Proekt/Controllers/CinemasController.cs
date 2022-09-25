using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proekt.Models;

namespace Proekt.Controllers
{
    public class CinemasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cinemas
        public ActionResult Index()
        {
            return View(db.Cinemas.ToList());
        }

        // GET: Cinemas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinema cinema = db.Cinemas.Find(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            return View(cinema);
        }
        [Authorize]
        public ActionResult Confirm(int? id)
        {
            if (id == null || id.Value < 1)
            {
                return View("Error");
            }
            List<Cinema> cinemas = db.Cinemas.ToList();
            return View("Index", cinemas);
        }
        [Authorize]
        public ActionResult Purchase(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinema cinema = db.Cinemas.Find(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            return View(cinema);
        }
        // GET: Cinemas/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cinemas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CinemaName,StartTime,Date,Name,Price")] Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                db.Cinemas.Add(cinema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cinema);
        }

        // GET: Cinemas/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinema cinema = db.Cinemas.Find(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            return View(cinema);
        }

        // POST: Cinemas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CinemaName,StartTime,Date,Name,Price")] Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cinema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cinema);
        }

        // GET: Cinemas/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinema cinema = db.Cinemas.Find(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            return View(cinema);
        }

        // POST: Cinemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            Cinema cinema = db.Cinemas.Find(id);
            db.Cinemas.Remove(cinema);
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
