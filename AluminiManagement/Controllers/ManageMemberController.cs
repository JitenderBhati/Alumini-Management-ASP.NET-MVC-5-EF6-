using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using AluminiManagement.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AluminiManagement.Controllers
{
    public class ManageMemberController : Controller
    {
        ApplicationDbContext _con;
        public ManageMemberController()
        {
            _con = new ApplicationDbContext();
        }
        //Disposing the con with database
        protected override void Dispose(bool disposing)
        {
            _con.Dispose();
        }
        [Authorize]
        // GET: ManageMember
        public ActionResult AddMember()
        {
            tbl_MemberForm obj = new tbl_MemberForm();
            return View(obj);
        }

        [Authorize]
        public ActionResult Index()
        {
            var data = _con.MemberForm.ToList();
            return View(data);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            var data = _con.MemberForm.SingleOrDefault(c => c.id == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View("AddMember", data);
        }

        public ActionResult chat()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveMembers(tbl_MemberForm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.id == 0)
            {
                var data = _con.MemberForm.Count(c => (c.email.Equals(model.email)) || (c.uid == model.uid));
                if (data == 0)
                {
                    string filename = Path.GetFileNameWithoutExtension(model.imagefile.FileName);
                    string extension = Path.GetExtension(model.imagefile.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                    model.imagepath = "~/images/" + filename;
                    filename = Path.Combine(Server.MapPath("~/images/"), filename);
                    model.imagefile.SaveAs(filename);
                    _con.MemberForm.Add(model);
                    _con.SaveChanges();                  
                    SendMail(model.email.ToString(), model.password.ToString());        
                    Response.Write("<script>alert('Alumini Successfully Added');</script>");
                }
                else
                {
                    Response.Write("<script>alert('User Already Exist');</script>");
                    return View("AddMember", model);
                }
            }
            else
            {
                var data = _con.MemberForm.SingleOrDefault(c => c.id == model.id);
                if (data == null)
                    return HttpNotFound();
                string filename = Path.GetFileNameWithoutExtension(model.imagefile.FileName);
                string extension = Path.GetExtension(model.imagefile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                model.imagepath = "~/images/" + filename;
                filename = Path.Combine(Server.MapPath("~/images/"), filename);
                model.imagefile.SaveAs(filename);
                TryUpdateModel(data);
                _con.SaveChanges();
                SendMail(model.email.ToString(), model.password.ToString());
                Response.Write("<script>alert('Alumini Successfully Updated');</script>");
            }
            return RedirectToAction("Index", "ManageMember");
        }

        public void SendMail(string email, string pass)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(ConfigurationManager.AppSettings["Email"]);
            message.To.Add(new MailAddress(email));
            message.Subject = "Credentials For Alumni Login";
            string body = "<h3><strong><u>As you are a member of alumini management.</u></strong></h3><br />" +
                "<u>Your Credentials for Alumini Are</u>" +
                "<br /><br /><u> Email</u>:  " + email + "<br /><u>Password</u>: " + pass + "<br /><br />To Visit Webpage: http://localhost:9397/MainPage/Index" + "<br /><br />To Login Visit http://localhost:9397/AluminiLogin/Login";
            message.Body = body;
            message.IsBodyHtml = true;
            message.Priority = MailPriority.Normal;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            NetworkCredential nc = new NetworkCredential(ConfigurationManager.AppSettings["Email"], ConfigurationManager.AppSettings["Password"]);
            client.UseDefaultCredentials = true;
            client.Credentials = nc;
            client.Send(message);
        }               
    }
}