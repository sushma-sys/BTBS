using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTBS.MVC.Models
{
    public class AdminViewModel
    {
       // [Required]
        public int Admin_Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First name should be minimum 3 letters")]
        public string First_Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last name should be minimum 3 letters")]
        public string Last_Name { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string Phone_No { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)\S{6,20}$", ErrorMessage = "Minimum 6 Max 20 characters atleast 1 Alphabet, 1 Number and 1 Special Character and avoid space")]
        public string Password { get; set; }
    }
}