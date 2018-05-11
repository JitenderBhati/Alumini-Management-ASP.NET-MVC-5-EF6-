using AluminiManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AluminiManagement.Controllers
{
    [AllowAnonymous]
    public class MainPageController : Controller
    {
        private ApplicationDbContext _con;
        public MainPageController()
        {
            _con = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _con.Dispose();
        }
        // GET: MainPage
        public ActionResult Index()
        {
            var data = _con.Events.ToList();
            return View(data);
        }

        public ActionResult AboutPage()
        {
            return View();
        }

        public ActionResult GalleryPage()
        {
            var data = _con.Gallery.ToList();
            return View(data);
        }
        public ActionResult ContactPage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveData(tbl_getintouch obj)
        {
            obj.date = DateTime.Now;
            _con.GetInTouch.Add(obj);
            _con.SaveChanges();
            return RedirectToAction("ContactPage", "MainPage");
        }
    }
}