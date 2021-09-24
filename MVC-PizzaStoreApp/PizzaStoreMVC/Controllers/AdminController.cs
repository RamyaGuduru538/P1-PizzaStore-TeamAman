using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaRepository.Classes;
using PizzaDbData;

namespace PizzaStoreMVC.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        OrderPizzaRepo orderRepo;
        public AdminController()
        {
            orderRepo = new OrderPizzaRepo(new PizzaDb());
        }
        // GET: Admin
        public ActionResult GetAllOrderHistory()
        {
            List<Models.OrderHistory> orderData = new List<Models.OrderHistory>();

            var data = orderRepo.GetAllOrderHistory();
            foreach (var order in data)
            {
                orderData.Add(new Models.OrderHistory()
                {
                    OrderId = order.OrderID,
                    PizzaName = order.Pizza.name,
                    PizzaSize = order.Size.name,
                    PizzaTopping = order.Topping.name,
                    TotalBill = order.TotalBill,
                    DateofOrder = (DateTime)order.OrderTime
                });
            }
            return View(orderData);
        }
        public ActionResult AddPizza()
        {
          return View();
        }
        [HttpPost]
        public ActionResult AddPizza(Models.AddPizza obj)
        {
            if (ModelState.IsValid)
            {
                var objPizza = new PizzaDbData.Pizza() { name=obj.Name,price=obj.Price};
                var objInventory = new PizzaDbData.Inventory() { name = obj.Name, quantity = obj.Quantity };

                orderRepo.AddPizza(objPizza,objInventory);
                ModelState.Clear();
                TempData["Message"] = "Item Added Successfully";
                TempData["color"] = "green";
                return View();
            }
            return View();
        }

        public ActionResult AddTopping()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTopping(Models.AddTopping obj)
        {
            if (ModelState.IsValid)
            {
                var objTopp = new PizzaDbData.Topping() { name = obj.Name, price = obj.Price };

                orderRepo.AddTopping(objTopp);
                ModelState.Clear();
                TempData["Message"] = "Item Added Successfully";
                TempData["color"] = "green";
                return View();
            }
            return View();
        }
    }
}