using AluminiManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AluminiManagement.Controllers
{
    public class EventManagementController : Controller
    {
        private ApplicationDbContext _con;
        public EventManagementController()
        {
            _con = new ApplicationDbContext();
        }      
        protected override void Dispose(bool disposing)
        {
            _con.Dispose();
        }
        // GET: EventManagement
        public ActionResult Index()
        {
            var data = _con.Events.ToList();
            return View(data);         
        }
    }
}