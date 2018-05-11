using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace AluminiManagement.Models
{
    public class tbl_MemberForm
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "University Id No ")]
        public string uid { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Name Of Alumini")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(10)]
        public string phoneNo { get; set; }

        [Required]
        [Display(Name = "Email Id")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dateofbirth { get; set; }

        [Required]
        [Display(Name = "Address")]
        [StringLength(255)]
        public string address { get; set; }


        [Required]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Leaving College")]
        public DateTime collegelastdate { get; set; }

        [Required]
        [MinLength(8)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Upload Photo")]
        public string imagepath { get; set; }

        [NotMapped]
        public HttpPostedFileBase imagefile { get; set; }

    }
}