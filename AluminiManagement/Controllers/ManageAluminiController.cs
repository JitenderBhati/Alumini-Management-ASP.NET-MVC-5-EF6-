using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using AluminiManagement.Models;
using Microsoft.AspNet.Identity;

namespace AluminiManagement.Controllers
{
    public class ManageAluminiController : Controller
    {
        private ApplicationDbContext _con;
        public ManageAluminiController()
        {
            _con = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _con.Dispose();
        }
        // GET: ManageAlumini
        public ActionResult Index()
        {
            var dat = (string)System.Web.HttpContext.Current.Session["EmailId"];
            var data = _con.MemberForm.SingleOrDefault(c => c.email.Equals(dat));
            return View(data);
        }

        public ActionResult Edit()
        {
            var dat = (string)System.Web.HttpContext.Current.Session["EmailId"];
            var data = _con.MemberForm.SingleOrDefault(c => c.email.Equals(dat));
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveData(tbl_MemberForm model)
        {
            var dat = (string)System.Web.HttpContext.Current.Session["EmailId"];
            var data = _con.MemberForm.SingleOrDefault(c => c.email.Equals(dat));
            TryUpdateModel(data);
            _con.SaveChanges();
            return RedirectToAction("Index", "ManageAlumini");
        }

        public ActionResult chat()
        {
            return View();
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "MainPage");
        }
    }
}