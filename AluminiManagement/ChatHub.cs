using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AluminiManagement.Models;
using Microsoft.AspNet.SignalR;

namespace AluminiManagement
{
    public class ChatHub : Hub
    {
        private ApplicationDbContext _con;
        public ChatHub()
        {
            _con = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _con.Dispose();
        }
        public override System.Threading.Tasks.Task OnConnected()
        {
            Clients.All.user(Context.User.Identity.Name);
            return base.OnConnected();
        }

        public void send(string message)
        {
            Clients.Caller.message("You:  " + message);
            Clients.Others.message("Chatter:  " + ": " + message);
        }
    }
}