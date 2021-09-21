using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PizzaDbData
{
    public partial class PizzaDb : DbContext
    {
        public PizzaDb()
            : base("name=PizzaDb")
        {
        }

        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<OrderHistory> OrderHistories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TakingPizzaOrder> TakingPizzaOrders { get; set; }
        public virtual DbSet<Topping> Toppings { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderHistories)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Payments)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.method)
                .IsUnicode(false);

            modelBuilder.Entity<Pizza>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Pizza>()
                .HasMany(e => e.TakingPizzaOrders)
                .WithRequired(e => e.Pizza)
                .HasForeignKey(e => e.PizzasId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Size>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Size>()
                .HasMany(e => e.TakingPizzaOrders)
                .WithRequired(e => e.Size)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Topping>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Topping>()
                .HasMany(e => e.TakingPizzaOrders)
                .WithRequired(e => e.Topping)
                .HasForeignKey(e => e.ToppID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Gender)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Logins)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TakingPizzaOrders)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);
        }
    }
}
