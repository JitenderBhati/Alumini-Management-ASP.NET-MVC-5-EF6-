using AluminiManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AluminiManagement.Controllers
{
    [Authorize]
    public class GetInTouchController : Controller
    {
        private ApplicationDbContext _con;

        public GetInTouchController()
        {
            _con = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _con.Dispose();
        }
        // GET: 

        public ActionResult SeenData()
        {
            var data = _con.GetInTouch.ToList();
            return View(data);
        }
        

        
    }
}