using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using LockhoodApp.Models;
using LockhoodApp.Report;

namespace LockhoodApp.Controllers
{
    public class OrderSalesController : Controller
    {
        private LockHoodDBEntities db = new LockHoodDBEntities();

        // GET: OrderSales
        public ActionResult Index()
        {
            var orderSales = db.OrderSales.Include(o => o.Cutomer);
            return View(orderSales.ToList());
        }

        // GET: OrderSales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderSale orderSale = db.OrderSales.Find(id);
            if (orderSale == null)
            {
                return HttpNotFound();
            }
            return View(orderSale);
        }

        public ActionResult exportReport()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "CrystalReport1.rpt"));
            rd.SetDataSource(db.OrderSales.ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "OrderSales.pdf");
            }
            catch
            {
                throw;
            }
        }

        // GET: OrderSales/Create
        public ActionResult Create()
        {
            ViewBag.customerID = new SelectList(db.Cutomers, "cusID", "name");
            return View();
        }

        // POST: OrderSales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "salesID,qty,expectedDate,customerID")] OrderSale orderSale)
        {
            if (ModelState.IsValid)
            {
                db.OrderSales.Add(orderSale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customerID = new SelectList(db.Cutomers, "cusID", "name", orderSale.customerID);
            return View(orderSale);
        }

        // GET: OrderSales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderSale orderSale = db.OrderSales.Find(id);
            if (orderSale == null)
            {
                return HttpNotFound();
            }
            ViewBag.customerID = new SelectList(db.Cutomers, "cusID", "name", orderSale.customerID);
            return View(orderSale);
        }

        // POST: OrderSales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "salesID,qty,expectedDate,customerID")] OrderSale orderSale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderSale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customerID = new SelectList(db.Cutomers, "cusID", "name", orderSale.customerID);
            return View(orderSale);
        }

        // GET: OrderSales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderSale orderSale = db.OrderSales.Find(id);
            if (orderSale == null)
            {
                return HttpNotFound();
            }
            return View(orderSale);
        }

        // POST: OrderSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderSale orderSale = db.OrderSales.Find(id);
            db.OrderSales.Remove(orderSale);
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
