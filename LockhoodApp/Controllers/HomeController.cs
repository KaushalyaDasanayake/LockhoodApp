using LockhoodApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LockhoodApp.Controllers
{
    public class HomeController : Controller
    {
        private LockHoodDBEntities db = new LockHoodDBEntities();

        public ActionResult Index()
        {
            return View(db.WorkTasks.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Report()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}