using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PaupWebDucan.Models;

namespace PaupWebDucan.Controllers
{
    public class KategorijeController : Controller
    {
        private BazaDbContext db = new BazaDbContext();

        // GET: Kategorije
        public ActionResult Index()
        {
            return View(db.PopisKategorija.ToList());
        }

        // GET: Kategorije/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategorije kategorije = db.PopisKategorija.Find(id);
            if (kategorije == null)
            {
                return HttpNotFound();
            }
            return View(kategorije);
        }

        // GET: Kategorije/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kategorije/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaterijalIzrade,NazivKategorije,ZastarjeliModel")] Kategorije kategorije)
        {
            if (ModelState.IsValid)
            {
                db.PopisKategorija.Add(kategorije);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategorije);
        }

        // GET: Kategorije/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategorije kategorije = db.PopisKategorija.Find(id);
            if (kategorije == null)
            {
                return HttpNotFound();
            }
            return View(kategorije);
        }

        // POST: Kategorije/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaterijalIzrade,NazivKategorije,ZastarjeliModel")] Kategorije kategorije)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategorije).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategorije);
        }

        // GET: Kategorije/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategorije kategorije = db.PopisKategorija.Find(id);
            if (kategorije == null)
            {
                return HttpNotFound();
            }
            return View(kategorije);
        }

        // POST: Kategorije/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Kategorije kategorije = db.PopisKategorija.Find(id);
            db.PopisKategorija.Remove(kategorije);
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
