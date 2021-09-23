using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace PizzaStoreMVC.Models
{
    public class OrderHistory
    {
        [DisplayName("Order Id")]
        public int OrderId { get; set; }
        [DisplayName("Pizza Name")]
        public string PizzaName { get; set; }

        [DisplayName("Pizza Size")]
        public string PizzaSize { get; set; }
        [DisplayName("Pizza Topping")]

        public string PizzaTopping { get; set; }
        [DisplayName("Total Bill")]

        public int TotalBill { get; set; }
        [DisplayName("Date of Order")]
        public DateTime? DateofOrder { get; set; }
    }
}