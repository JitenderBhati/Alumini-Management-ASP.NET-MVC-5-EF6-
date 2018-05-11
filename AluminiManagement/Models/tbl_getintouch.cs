using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AluminiManagement.Models
{
    public class tbl_getintouch
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        [StringLength(10)]
        public string mobileNo { get; set; }

        [Required]
        [StringLength(20)]
        public string email { get; set; }

        [Required]
        [StringLength(200)]
        public string message { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
    }
}