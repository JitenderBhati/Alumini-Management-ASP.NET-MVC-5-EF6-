using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AluminiManagement.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AluminiManagement.Controllers
{
    [Authorize]
    public class ChangePasswordController : Controller
    {
        ApplicationDbContext _con;
        public ChangePasswordController()
        {
            _con = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _con.Dispose();
        }      
        // GET: ChangePassword
        public ActionResult PasswordChange()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PasswordChanged(PasswordChange model)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(store);
            String userId = User.Identity.GetUserId();//"<YourLogicAssignsRequestedUserId>";             
            String hashedNewPassword = UserManager.PasswordHasher.HashPassword(model.password);
            ApplicationUser cUser = await store.FindByIdAsync(userId);
            await store.SetPasswordHashAsync(cUser, hashedNewPassword);
            await store.UpdateAsync(cUser);
            Response.Write("<script>alert('Password Successfully Changed');</script>");
            return View("PasswordChange");
        }

    }
}