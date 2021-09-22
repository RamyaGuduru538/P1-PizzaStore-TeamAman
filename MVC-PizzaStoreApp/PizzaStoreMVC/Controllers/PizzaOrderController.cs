using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaRepository.Classes;
using PizzaDbData;
namespace PizzaStoreMVC.Controllers
{
    public class PizzaOrderController : Controller
    {
        OrderPizzaRepo orderRepo;
        public PizzaOrderController()
        {
            orderRepo = new OrderPizzaRepo(new PizzaDb());
        }
        // GET: PizzaOrder
        public ActionResult OrderPizza()
        {
            ViewBag.PizzaName = new SelectList(orderRepo.GetPizzaName(), "id", "Name");
            ViewBag.PizzaSize = new SelectList(orderRepo.GetPizzaSize(), "id", "Name");
            ViewBag.PizzaTopping = new SelectList(orderRepo.GetPizzaTopping(), "id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult OrderPizza(Models.OrderPizza obj)
        {
            PizzaDbData.TakingPizzaOrder orderObj = new PizzaDbData.TakingPizzaOrder();
            if (ModelState.IsValid)
            {
                int userid=0;
                if (Session["userid"] != null)
                    userid = (int)Session["userid"];
                if (userid > 0)
                {
                    orderObj.PizzasId = obj.PizzaName;
                    orderObj.SizeId = obj.PizzaSize;
                    orderObj.ToppID = obj.PizzaTopping;
                    orderObj.user_id = userid;
                    orderObj.OrderTime = DateTime.Now;
                    int quantity = orderRepo.GetQuantity(obj.PizzaName);
                    if (quantity > 0)
                    {
                        orderRepo.AddOrderData(orderObj);
                        TempData["Message"] = "Order Placed Successfully";
                        TempData["color"] = "green";
                        return RedirectToAction("OrderPizza", "PizzaOrder");
                    }
                    else
                    {
                        TempData["Message"] = "Currently this Pizza is Out of Stock";
                        TempData["color"] = "red";
                        return RedirectToAction("OrderPizza", "PizzaOrder");
                    }
                }
                else
                {
                    TempData["Message"] = "Please Login First to Place the Order";
                    TempData["color"] = "red";
                    return RedirectToAction("OrderPizza", "PizzaOrder");
                }
                
            }
            TempData["Message"] = "Please Select Details";
            TempData["color"] = "red";
            return RedirectToAction("OrderPizza", "PizzaOrder");
        }

        public ActionResult GetOrderHistory()
        {
            List<Models.OrderHistory> orderData = new List<Models.OrderHistory>();

            int userid = (int)Session["userid"];
            var data = orderRepo.GetOrderHistoryById(userid);
            foreach(var order in data)
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
        [HttpPost]
        public int GetTotalBill(Models.OrderPizza obj)
        {
            int totalBill=0;
            PizzaDbData.TakingPizzaOrder orderObj = new PizzaDbData.TakingPizzaOrder();
            if (obj.PizzaName>0 && obj.PizzaSize>0 && obj.PizzaSize > 0)
            {
                int userid = 0;
                if (Session["userid"] != null)
                    userid = (int)Session["userid"];
                if (userid > 0)
                {
                    orderObj.PizzasId = obj.PizzaName;
                    orderObj.SizeId = obj.PizzaSize;
                    orderObj.ToppID = obj.PizzaTopping;
                    orderObj.user_id = userid;
                    orderObj.OrderTime = DateTime.Now;
                   
                    totalBill = orderRepo.GetBillPrice(orderObj);
                    TempData["Message"] = "Order Placed Successfully";
                    TempData["color"] = "green";
                    return totalBill;
                }
                else
                {
                    TempData["Message"] = "Please Login First";
                    TempData["color"] = "red";
                    return totalBill;
                }
            }
            TempData["Message"] = "Please select item";
            TempData["color"] = "red";
            return totalBill;
        }
    }
}