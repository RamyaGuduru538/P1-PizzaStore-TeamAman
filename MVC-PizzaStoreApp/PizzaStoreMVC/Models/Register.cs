using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PizzaStoreMVC.Models
{
    public class Register
    {
        public int id { get; set; }
        [DisplayName("Full Name")]
        [Required(ErrorMessage = "Name cannot be blank")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only Alphabets are allowed.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email cannot be blank")]
        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$",
        ErrorMessage = "Email must be properly formatted.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Zipcode cannot be blank")]
        [RegularExpression(@"^(\d{5})$", ErrorMessage = "Length Must be exact 5 and cannot start with 0")]

        public int? Zipcode { get; set; }



        [Required(ErrorMessage = "Gender cannot be blank")]
        public char Gender { get; set; }


        [DisplayName("Password:")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password cannot be blank")]
        [MinLength(5, ErrorMessage = "Length Must be greater than 5"), MaxLength(13, ErrorMessage = "Length Must be less than 13")]
        public string Password { get; set; }


        [DisplayName("Re-Password:")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string cPassword { get; set; }

    }
}