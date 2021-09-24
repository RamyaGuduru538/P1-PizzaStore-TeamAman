using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PizzaStoreMVC.Models
{
    public class ContactUs
    {
        [Required, Display(Name = "Name")]
        public string FromName { get; set; }
        [Required, Display(Name = "Email"), EmailAddress]
        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$",
        ErrorMessage = "Please Enter Valid Email.")]
        public string FromEmail { get; set; }

        [Required]
        public string Message { get; set; }
    }
}