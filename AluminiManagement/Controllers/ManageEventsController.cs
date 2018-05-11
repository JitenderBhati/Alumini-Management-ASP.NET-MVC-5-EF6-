using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AluminiManagement.Models;

namespace AluminiManagement.Controllers
{
    [Authorize]
    public class ManageEventsController : Controller
    {
        private ApplicationDbContext _con;
        public ManageEventsController()
        {
            _con = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _con.Dispose();
        }
        // GET: ManageEvents
        public ActionResult Index()
        {
            var data = _con.Events.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult AddEvents()
        {
            tbl_Events obj = new tbl_Events();
            return View(obj);
        }

        [HttpPost]
        public ActionResult SaveEvents(tbl_Events model)
        {
            if (model.id == 0)
            {
                string filename = Path.GetFileNameWithoutExtension(model.imagefile.FileName);
                string extension = Path.GetExtension(model.imagefile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                model.imagepath = "~/Events/" + filename;
                filename = Path.Combine(Server.MapPath("~/Events/"), filename);
                model.imagefile.SaveAs(filename);
                _con.Events.Add(model);
            }
            else
            {
                var data = _con.Events.SingleOrDefault(c => c.id == model.id);
                if (data == null)
                {
                    return HttpNotFound();
                }
                string filename = Path.GetFileNameWithoutExtension(model.imagefile.FileName);
                string extension = Path.GetExtension(model.imagefile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                model.imagepath = "~/Events/" + filename;
                filename = Path.Combine(Server.MapPath("~/Events/"), filename);
                model.imagefile.SaveAs(filename);
                data.desc = model.desc;
                if (model.dateofevent>DateTime.Now)
                {
                    data.dateofevent = model.dateofevent;
                }
                data.dateofevent = data.dateofevent;
                data.imagepath = model.imagepath;
                data.name = model.name;
            }
            _con.SaveChanges();
            return RedirectToAction("Index", "ManageEvents");
        }

        public ActionResult Edit(int id)
        {
            var data = _con.Events.SingleOrDefault(c => c.id == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View("AddEvents", data);
        }
    }
}