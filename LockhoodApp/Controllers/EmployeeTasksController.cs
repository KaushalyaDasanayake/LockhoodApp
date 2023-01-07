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
    public class EmployeeTasksController : Controller
    {
        private LockHoodDBEntities db = new LockHoodDBEntities();

        // GET: EmployeeTasks
        public ActionResult Index()
        {
            var employeeTasks = db.EmployeeTasks.Include(e => e.WorkTask).Include(e => e.Employee);
            return View(employeeTasks.ToList());
        }

        // GET: EmployeeTasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTask employeeTask = db.EmployeeTasks.Find(id);
            if (employeeTask == null)
            {
                return HttpNotFound();
            }
            return View(employeeTask);
        }

        // GET: EmployeeTasks/Create
        public ActionResult Create()
        {
            ViewBag.worktaskID = new SelectList(db.WorkTasks, "ID", "Name");
            ViewBag.empName = new SelectList(db.Employees, "name", "fullName");
            return View();
        }

        // POST: EmployeeTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "taskID,worktaskID,empName,allocatedHours")] EmployeeTask employeeTask)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeTasks.Add(employeeTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.worktaskID = new SelectList(db.WorkTasks, "ID", "Name", employeeTask.worktaskID);
            ViewBag.empName = new SelectList(db.Employees, "name", "fullName", employeeTask.empName);
            return View(employeeTask);
        }

        // GET: EmployeeTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTask employeeTask = db.EmployeeTasks.Find(id);
            if (employeeTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.worktaskID = new SelectList(db.WorkTasks, "ID", "Name", employeeTask.worktaskID);
            ViewBag.empName = new SelectList(db.Employees, "name", "fullName", employeeTask.empName);
            return View(employeeTask);
        }

        // POST: EmployeeTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "taskID,worktaskID,empName,allocatedHours")] EmployeeTask employeeTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.worktaskID = new SelectList(db.WorkTasks, "ID", "Name", employeeTask.worktaskID);
            ViewBag.empName = new SelectList(db.Employees, "name", "fullName", employeeTask.empName);
            return View(employeeTask);
        }

        // GET: EmployeeTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTask employeeTask = db.EmployeeTasks.Find(id);
            if (employeeTask == null)
            {
                return HttpNotFound();
            }
            return View(employeeTask);
        }

        // POST: EmployeeTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeTask employeeTask = db.EmployeeTasks.Find(id);
            db.EmployeeTasks.Remove(employeeTask);
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
