using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PizzaStoreMVC.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Email cannot be blank")]
        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$",
        ErrorMessage = "Please Enter Valid Email.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password cannot be blank")]
        [MinLength(5,ErrorMessage ="Length Must be greater than 5"),MaxLength(13, ErrorMessage = "Length Must be less than 13")]
        public string Password { get; set; }

    }
}