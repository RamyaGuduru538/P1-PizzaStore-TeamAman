using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace PizzaStoreMVC.Models
{
    public class AddPizza
    {
        [DisplayName("Pizza Name")]
        [Required(ErrorMessage = "Name cannot be blank")]
        public string Name { get; set; }


        [DisplayName("Pizza Price")]
        [Required(ErrorMessage = "**Please Enter Price")]
        [Range(25,500,ErrorMessage =("Price Must be between 25 and 500"))]
        public int Price { get; set; }


        [DisplayName("Pizza Quantity")]
        [Required(ErrorMessage = "Please Enter Quantity")]
        [Range(5, int.MaxValue, ErrorMessage = ("Quantity Must be greater than 5"))]
        public int Quantity { get; set; }

    }
}