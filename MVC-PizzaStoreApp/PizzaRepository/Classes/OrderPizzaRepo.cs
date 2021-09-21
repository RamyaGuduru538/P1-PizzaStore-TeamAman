using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaDbData;

namespace PizzaRepository.Classes
{
   public  class OrderPizzaRepo
    {
        private PizzaDb db;
        public OrderPizzaRepo(PizzaDb db)
        {
            this.db = db;
        }
        public IEnumerable<Pizza> GetPizzaName()
        {
            return db.Pizzas.ToList();
        }
        public IEnumerable<Size> GetPizzaSize()
        {
            return db.Sizes.ToList();
        }
        public IEnumerable<Topping> GetPizzaTopping()
        {
            return db.Toppings.ToList();
        }

        public void AddOrderData(TakingPizzaOrder obj)
        {
            int Pizzaid = obj.PizzasId;
            UpdateInventory(Pizzaid);
            db.TakingPizzaOrders.Add(obj);
            db.SaveChanges();
        }    
        public void UpdateInventory(int Pizzaid)
        {
            Inventory data = db.Inventories.Where(s => s.id == Pizzaid).FirstOrDefault();
            int quantity = data.quantity - 1;
            data.quantity = quantity;
            db.SaveChanges();
        }
        public int GetQuantity(int Pizzaid)
        {
            return db.Inventories.Where(s => s.id == Pizzaid).Select(s => s.quantity).FirstOrDefault();
        }
    }
}
