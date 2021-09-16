namespace PizzaDbData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string status { get; set; }

        [Required]
        [StringLength(30)]
        public string method { get; set; }

        public int OrderID { get; set; }

        public virtual Order Order { get; set; }
    }
}
