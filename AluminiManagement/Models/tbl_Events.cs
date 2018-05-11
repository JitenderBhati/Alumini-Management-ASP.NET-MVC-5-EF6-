using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AluminiManagement.Models
{
    public class tbl_Events
    {
        public int id { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name ="Event Name")]
        public string name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd MM yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Event")]
        public DateTime dateofevent { get; set; }

        [Display(Name ="Description")]
        [StringLength(300)]
        public string desc { get; set; }

        [NotMapped]
        public HttpPostedFileBase imagefile { get; set; }

        [Display(Name ="Upload Photo")]
        public string imagepath { get; set; }

    }
}