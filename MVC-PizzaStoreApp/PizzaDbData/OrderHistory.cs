namespace PizzaDbData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderHistory")]
    public partial class OrderHistory
    {
        public int id { get; set; }

        public int OrderID { get; set; }

        public int PizzaID { get; set; }

        public int SizeID { get; set; }

        public int ToppingID { get; set; }

        public int TotalBill { get; set; }

        public DateTime? OrderTime { get; set; }

        public virtual Pizza Pizza { get; set; }

        public virtual Size Size { get; set; }

        public virtual TakingPizzaOrder TakingPizzaOrder { get; set; }

        public virtual Topping Topping { get; set; }
    }
}
