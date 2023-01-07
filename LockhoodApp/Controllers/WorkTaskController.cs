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
    public class WorkTaskController : Controller
    {
        private LockHoodDBEntities db = new LockHoodDBEntities();

        // GET: WorkTask
        public ActionResult Index()
        {
            var workTasks = db.WorkTasks.Include(w => w.OrderSale).Include(w => w.Product);
            return View(workTasks.ToList());
        }

        // GET: WorkTask/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTask workTask = db.WorkTasks.Find(id);
            if (workTask == null)
            {
                return HttpNotFound();
            }
            return View(workTask);
        }

        // GET: WorkTask/Create
        public ActionResult Create()
        {
            ViewBag.salesId = new SelectList(db.OrderSales, "salesID", "salesID");
            ViewBag.productId = new SelectList(db.Products, "ProductID", "type");
            return View();
        }

        public void UpdateQuantity(int? productId, int qty)
        {
            List<ProductItem> itemList = db.ProductItems.Where(i => i.productId == productId).ToList();

            foreach (var item in itemList)
            {
                if (item.itemId != 0)
                {
                    Inventory inventory_ = db.Inventories.Find(item.itemId);
                    inventory_.qty = inventory_.qty - (item.qty * qty);
                    db.Entry(inventory_).State = EntityState.Modified;
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                }
            }
        }

        public void InventoryWarning(int? productId)
        {
            List<ProductItem> itemList = db.ProductItems.Where(i => i.productId == productId).ToList();
            foreach (var item in itemList)
            {
                Inventory inventory_ = db.Inventories.Find(item.itemId);
                if (inventory_.qty <= inventory_.item_warningLevel)
                {
                    TempData["AlertMessage"] = "Inventory is low! Please order new items soon...!"; // aleart eka view karanna frontend eke
                }
                //return RedirectToAction("Index");
            }
        }
        // POST: WorkTask/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,salesId,productId,startingDate,expectedDate,status")] WorkTask workTask)
        {
            if (ModelState.IsValid)
            {
                db.WorkTasks.Add(workTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.salesId = new SelectList(db.OrderSales, "salesID", "salesID", workTask.salesId);
            ViewBag.productId = new SelectList(db.Products, "ProductID", "type", workTask.productId);
            return View(workTask);
        }

        // GET: WorkTask/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTask workTask = db.WorkTasks.Find(id);
            if (workTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.salesId = new SelectList(db.OrderSales, "salesID", "salesID", workTask.salesId);
            ViewBag.productId = new SelectList(db.Products, "ProductID", "type", workTask.productId);
            return View(workTask);
        }

        // POST: WorkTask/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,salesId,productId,startingDate,expectedDate,status")] WorkTask workTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.salesId = new SelectList(db.OrderSales, "salesID", "salesID", workTask.salesId);
            ViewBag.productId = new SelectList(db.Products, "ProductID", "type", workTask.productId);
            return View(workTask);
        }

        // GET: WorkTask/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTask workTask = db.WorkTasks.Find(id);
            if (workTask == null)
            {
                return HttpNotFound();
            }
            return View(workTask);
        }

        // POST: WorkTask/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkTask workTask = db.WorkTasks.Find(id);
            db.WorkTasks.Remove(workTask);
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
