using AluminiManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AluminiManagement.Controllers
{
    [Authorize]
    public class ManageGalleryController : Controller
    {

        private ApplicationDbContext _con;
        public ManageGalleryController()
        {
            _con = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _con.Dispose();
        }
        // GET: ManageGallery
        public ActionResult Index()
        {
            var data = _con.Gallery.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult AddGallery()
        {
            tbl_gallery obj = new tbl_gallery();
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveGallery(tbl_gallery model)
        {
            if(model.id==0)
            {
                string filename = Path.GetFileNameWithoutExtension(model.imagefile.FileName);
                string extension = Path.GetExtension(model.imagefile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                model.imagepath = "~/Gallery/" + filename;
                filename = Path.Combine(Server.MapPath("~/Gallery/"), filename);
                model.imagefile.SaveAs(filename);
                model.date = DateTime.Now;
                _con.Gallery.Add(model);
            }
            else
            {
                var data = _con.Gallery.SingleOrDefault(c => c.id == model.id);
                if(data==null)
                {
                    return HttpNotFound();
                }
                string filename = Path.GetFileNameWithoutExtension(model.imagefile.FileName);
                string extension = Path.GetExtension(model.imagefile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                model.imagepath = "~/Gallery/" + filename;
                filename = Path.Combine(Server.MapPath("~/Gallery/"), filename);
                model.imagefile.SaveAs(filename);                
                data.desc = model.desc;
                data.date = DateTime.Now;
                data.imagepath = model.imagepath;
                data.title = model.title;                
               
            }
            _con.SaveChanges();
            return RedirectToAction("Index", "ManageGallery");
        }

        public ActionResult Edit(int id)
        {
            var data = _con.Gallery.SingleOrDefault(c => c.id == id);
            if(data ==null)
            {
                return HttpNotFound();
            }

            return View("AddGallery", data);
        }
    }
}