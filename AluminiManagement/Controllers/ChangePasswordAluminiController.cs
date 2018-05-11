using AluminiManagement.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AluminiManagement.Controllers
{
   
    public class ChangePasswordAluminiController : Controller
    {
        ApplicationDbContext _con;
        public ChangePasswordAluminiController()
        {
            _con = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _con.Dispose();
        }
        // GET: ChangePasswordAlumini
        public ActionResult PasswordChange()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PasswordChanged(PasswordChange model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var data = (string)System.Web.HttpContext.Current.Session["EmailId"];
            var d = _con.MemberForm.SingleOrDefault(c => c.email.Equals(data));
            if(d!=null)
            {
                d.password = model.password;
                _con.SaveChanges();
            }
            //var email = Session["Emaild"].ToString();
            //var data = _con.MemberForm.SingleOrDefault(c => c.email.Equals(User.Identity.Name));
            //if (data == null)
            //{
            //    return Content(User.Identity.Name + " " + User.Identity.GetUserName());
            //}
            //TryUpdateModel(model);
            //_con.SaveChanges();            
            //ApplicationDbContext context = new ApplicationDbContext();
            //UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(context);
            //UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(store);
            //String userId = User.Identity.GetUserId();//"<YourLogicAssignsRequestedUserId>";             
            //String hashedNewPassword = UserManager.PasswordHasher.HashPassword(model.password);
            //ApplicationUser cUser = await store.FindByIdAsync(userId);
            //await store.SetPasswordHashAsync(cUser, hashedNewPassword);
            //await store.UpdateAsync(cUser);
            //UserManager<ApplicationDbContext> userm = new UserManager<ApplicationDbContext>();
            //var userName = User.Identity.Name;
            //var user =  await UserManager.FindByNameAsync(userName);
            //var data = await UserManager.ResetPasswordAsync(user.Id, model.password); 
            Response.Write("<script>alert('Password Successfully Changed');</script>");
           // PasswordChange obj = new PasswordChange();
            return View("PasswordChange");

        }
    }
}