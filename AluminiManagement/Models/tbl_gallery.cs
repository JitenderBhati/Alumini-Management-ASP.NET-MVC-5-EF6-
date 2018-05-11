using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AluminiManagement.Models
{
    public class tbl_gallery
    {
        public int id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }

        [Display(Name = "Upload Image")]
        [StringLength(200)]
        public string imagepath { get; set; }

        [Required]
        [Display(Name = "Title")]
        [StringLength(50)]
        public string title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string desc { get; set; }

        [NotMapped]

        public HttpPostedFileBase imagefile { get; set; }
    }
}