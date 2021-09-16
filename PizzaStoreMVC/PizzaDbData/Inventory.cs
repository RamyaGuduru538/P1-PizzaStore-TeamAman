namespace PizzaDbData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inventory")]
    public partial class Inventory
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public int quantity { get; set; }
    }
}
