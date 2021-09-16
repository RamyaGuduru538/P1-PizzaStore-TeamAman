namespace PizzaDbData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Size
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Size()
        {
            TakingPizzaOrders = new HashSet<TakingPizzaOrder>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(15)]
        public string name { get; set; }

        public int price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TakingPizzaOrder> TakingPizzaOrders { get; set; }
    }
}
