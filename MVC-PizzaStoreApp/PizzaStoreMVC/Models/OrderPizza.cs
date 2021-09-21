using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PizzaStoreMVC.Models
{
    public class OrderPizza
    {
        [Display(Name ="Pizza Name")]
        [Required(ErrorMessage ="Please choose Pizza Name")]
        public int PizzaName { get; set; }


        [Display(Name = "Pizza Size")]
        [Required(ErrorMessage = "Please choose Pizza size")]
        public int PizzaSize { get; set; }


        [Display(Name = "Pizza Topping")]
        [Required(ErrorMessage = "Please choose Pizza Topping")]
        public int PizzaTopping { get; set; }

    }
}