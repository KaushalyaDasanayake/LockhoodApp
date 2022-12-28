using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LockhoodApp.Models;

namespace LockhoodApp.Controllers
{
    public class CutomersController : Controller
    {
        private LockHoodDBEntities db = new LockHoodDBEntities();

        // GET: Cutomers
        public ActionResult Index()
        {
            return View(db.Cutomers.ToList());
        }

        // GET: Cutomers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cutomer cutomer = db.Cutomers.Find(id);
            if (cutomer == null)
            {
                return HttpNotFound();
            }
            return View(cutomer);
        }

        // GET: Cutomers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cutomers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cusID,name,company,address,contactNo,description,status")] Cutomer cutomer)
        {
            if (ModelState.IsValid)
            {
                db.Cutomers.Add(cutomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cutomer);
        }

        // GET: Cutomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cutomer cutomer = db.Cutomers.Find(id);
            if (cutomer == null)
            {
                return HttpNotFound();
            }
            return View(cutomer);
        }

        // POST: Cutomers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cusID,name,company,address,contactNo,description,status")] Cutomer cutomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cutomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cutomer);
        }

        // GET: Cutomers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cutomer cutomer = db.Cutomers.Find(id);
            if (cutomer == null)
            {
                return HttpNotFound();
            }
            return View(cutomer);
        }

        // POST: Cutomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cutomer cutomer = db.Cutomers.Find(id);
            db.Cutomers.Remove(cutomer);
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
