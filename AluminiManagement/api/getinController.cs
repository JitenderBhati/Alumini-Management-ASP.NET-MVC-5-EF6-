using AluminiManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AluminiManagement.api
{
    public class getinController : ApiController
    {
        private ApplicationDbContext _con;
        public getinController()
        {
            _con = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _con.Dispose();
        }
        [HttpDelete]
        public void delete(int id)
        {
            var data = _con.GetInTouch.SingleOrDefault(c => c.id == id);
            if (data == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _con.GetInTouch.Remove(data);
            _con.SaveChanges();

        }
    }
}
