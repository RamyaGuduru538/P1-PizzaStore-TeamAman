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
            var PizzaName = db.Pizzas.Where(p => p.id == obj.PizzasId).FirstOrDefault();
            var PizzaSize = db.Sizes.Where(p => p.id == obj.SizeId).FirstOrDefault();
            var PizzaTopp = db.Toppings.Where(p => p.id == obj.ToppID).FirstOrDefault();
            int totalBill = PizzaName.price + PizzaSize.price + PizzaTopp.price;
            int orderId = db.TakingPizzaOrders.Max(p => p.id);
            OrderHistory orderHist = new OrderHistory()
            {
                OrderID=orderId,
                PizzaID=obj.PizzasId,
                SizeID=obj.SizeId,
                ToppingID=obj.ToppID,
                OrderTime=obj.OrderTime,
                TotalBill=totalBill
            };
            db.OrderHistories.Add(orderHist);
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

        public IEnumerable<OrderHistory> GetOrderHistoryById(int userid)
        {
            List<int> orderIdList = db.TakingPizzaOrders.Where(o => o.user_id == userid).Select(o => o.id).ToList();
            List<OrderHistory> obj = new List<OrderHistory>();
            foreach(int id in orderIdList)
            {
                var tempdata = db.OrderHistories.Include("Pizza").Include("Size").Include("Topping")
                    .Where(o => o.OrderID == id).FirstOrDefault();
                obj.Add(new OrderHistory()
                {
                    OrderID = tempdata.OrderID,
                    PizzaID = tempdata.PizzaID,
                    SizeID = tempdata.SizeID,
                    ToppingID = tempdata.ToppingID,
                    OrderTime = tempdata.OrderTime,
                    TotalBill = tempdata.TotalBill,
                    Pizza=new Pizza() { name=tempdata.Pizza.name,price=tempdata.Pizza.price},
                    Size = new Size() { name = tempdata.Size.name, price = tempdata.Size.price },
                    Topping = new Topping() { name = tempdata.Topping.name, price = tempdata.Topping.price }
                }); 
            }
            return obj;
        }
        public IEnumerable<OrderHistory> GetAllOrderHistory()
        {
            List<int> orderIdList = db.TakingPizzaOrders.Select(o => o.id).ToList();
            List<OrderHistory> obj = new List<OrderHistory>();
            foreach (int id in orderIdList)
            {
                var tempdata = db.OrderHistories.Include("Pizza").Include("Size").Include("Topping")
                    .Where(o => o.OrderID == id).FirstOrDefault();
                obj.Add(new OrderHistory()
                {
                    OrderID = tempdata.OrderID,
                    PizzaID = tempdata.PizzaID,
                    SizeID = tempdata.SizeID,
                    ToppingID = tempdata.ToppingID,
                    OrderTime = tempdata.OrderTime,
                    TotalBill = tempdata.TotalBill,
                    Pizza = new Pizza() { name = tempdata.Pizza.name, price = tempdata.Pizza.price },
                    Size = new Size() { name = tempdata.Size.name, price = tempdata.Size.price },
                    Topping = new Topping() { name = tempdata.Topping.name, price = tempdata.Topping.price }
                });
            }
            return obj;
        }
        public int GetBillPrice(TakingPizzaOrder obj)
        {
            int pizzaPrice = db.Pizzas.Where(p => p.id == obj.PizzasId).Select(p => p.price).FirstOrDefault();
            int sizePrice = db.Sizes.Where(p => p.id == obj.SizeId).Select(p => p.price).FirstOrDefault();
            int toppPrice = db.Toppings.Where(p => p.id == obj.ToppID).Select(p => p.price).FirstOrDefault();
            return (pizzaPrice + sizePrice + toppPrice);
        }

        public void AddPizza(Pizza pizza,Inventory invent)
        {
            db.Pizzas.Add(pizza);
            db.Inventories.Add(invent);
            db.SaveChanges();
        }
        public void AddTopping(Topping topp)
        {
            db.Toppings.Add(topp);
            db.SaveChanges();
        }
    }
}
