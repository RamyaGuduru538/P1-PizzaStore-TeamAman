namespace PizzaDbData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Login")]
    public partial class Login
    {
        public int id { get; set; }

        public int user_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public virtual User User { get; set; }
    }
}
