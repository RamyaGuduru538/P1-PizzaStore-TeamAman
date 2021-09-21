namespace PizzaDbData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TakingPizzaOrder
    {
        public int id { get; set; }

        public int PizzasId { get; set; }

        public int SizeId { get; set; }

        public int ToppID { get; set; }

        public int user_id { get; set; }

        public virtual Pizza Pizza { get; set; }

        public virtual Size Size { get; set; }

        public virtual Topping Topping { get; set; }

        public virtual User User { get; set; }
    }
}
