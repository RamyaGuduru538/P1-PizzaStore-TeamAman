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
                orderObj.PizzasId = obj.PizzaName;
                orderObj.SizeId = obj.PizzaSize;
                orderObj.ToppID = obj.PizzaTopping;
                orderObj.user_id = (int)Session["userid"];
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
            TempData["Message"] = "Please Select Details";
            TempData["color"] = "red";
            return RedirectToAction("OrderPizza", "PizzaOrder");
        }
    }
}