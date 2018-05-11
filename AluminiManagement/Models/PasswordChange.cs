using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AluminiManagement.Models
{
    public class PasswordChange
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="New Password")]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("password", ErrorMessage ="Password Doesn`t Match")]
        public string confirmpassword { get; set; }
    }
}