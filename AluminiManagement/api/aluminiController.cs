using AluminiManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AluminiManagement.api
{
    public class aluminiController : ApiController
    {
        private ApplicationDbContext _con;
        public aluminiController()
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
            var data = _con.MemberForm.SingleOrDefault(c => c.id == id);
            if(data==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _con.MemberForm.Remove(data);
            _con.SaveChanges();
           

        }
    }
}
