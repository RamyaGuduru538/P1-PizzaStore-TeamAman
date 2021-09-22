namespace PizzaDbData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TakingPizzaOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TakingPizzaOrder()
        {
            OrderHistories = new HashSet<OrderHistory>();
        }

        public int id { get; set; }

        public int PizzasId { get; set; }

        public int SizeId { get; set; }

        public int ToppID { get; set; }

        public int user_id { get; set; }

        public DateTime? OrderTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderHistory> OrderHistories { get; set; }

        public virtual Pizza Pizza { get; set; }

        public virtual Size Size { get; set; }

        public virtual Topping Topping { get; set; }

        public virtual User User { get; set; }
    }
}
