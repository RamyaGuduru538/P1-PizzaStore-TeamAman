using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace PizzaStoreMVC.Models
{
    public class ForgotPassword
    {
        [Required(ErrorMessage ="This is required")]
        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$",
        ErrorMessage = "Please Enter Valid Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="This is required")]
        [DataType(DataType.Password)]
        [MinLength(5,ErrorMessage ="Length of password must be between (5,13)"),MaxLength(13,ErrorMessage = "Length of password must be between (5,13)")]
        public string Password { get; set; }


        [DisplayName("Confirm Password")]
        [Required(ErrorMessage ="This is required")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Both Password Must be same")]
        public string cPassword { get; set; }

    }
}