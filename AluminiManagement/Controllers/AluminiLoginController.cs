using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AluminiManagement.Models;
namespace AluminiManagement.Controllers
{
    public class AluminiLoginController : Controller
    {
        private ApplicationDbContext _con;

        public AluminiLoginController()
        {
            _con = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _con.Dispose();
        }

        [AllowAnonymous]        
        // GET: AluminiLogin
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Authenticate(Alumini_Login obj)
        {
            var data = _con.MemberForm.SingleOrDefault(c => (c.email.Equals(obj.email))&&(c.password.Equals(obj.password)));
            if(data==null)
            {
                //
                Response.Write("<script>alert('Email or Password is Incorrect');</script>");
                return View("Login");
            }
            System.Web.HttpContext.Current.Session["EmailId"] = obj.email;          
            return RedirectToAction("Index", "ManageAlumini");
        }
    }
}