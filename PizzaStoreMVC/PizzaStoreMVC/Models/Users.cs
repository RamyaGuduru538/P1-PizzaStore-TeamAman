using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaStoreMVC.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Zipcode { get; set; }
        public char Gender { get; set; }

    }
}