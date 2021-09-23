using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaStoreMVC.Models
{
    public class AddTopping
    {
        [DisplayName("Topping Name")]
        [Required(ErrorMessage = "Name cannot be blank")]
        public string Name { get; set; }

        [DisplayName("Topping Price")]
        [Required(ErrorMessage = "Please Enter Price")]
        [Range(25, 200, ErrorMessage = ("Price Must be between 25 and 200"))]
        public int Price { get; set; }
    }
}