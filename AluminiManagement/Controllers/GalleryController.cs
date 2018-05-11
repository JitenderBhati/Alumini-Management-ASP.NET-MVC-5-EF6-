using AluminiManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AluminiManagement.Controllers
{

    public class GalleryController : Controller
    {      
        private ApplicationDbContext _con;
        public GalleryController()
        {
            _con = new ApplicationDbContext();
        }
       
        protected override void Dispose(bool disposing)
        {
            _con.Dispose();
        }
        // GET: Gallery
        public ActionResult ViewGallery()
        {
            var data = _con.Gallery.ToList();
            return View(data);
        }      
   
        public ActionResult Views(int id)
        {
            var data = _con.Gallery.SingleOrDefault(c => c.id == id);
            if (data == null)
                return HttpNotFound();
            return View(data);
        }
    }
}