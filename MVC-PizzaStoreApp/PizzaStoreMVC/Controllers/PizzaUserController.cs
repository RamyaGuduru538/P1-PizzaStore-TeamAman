using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaRepository.Classes;
using PizzaDbData;

namespace PizzaStoreMVC.Controllers
{
    public class PizzaUserController : Controller
    {
        UserRepository userRepo;
        public PizzaUserController()
        {
            userRepo = new UserRepository(new PizzaDb());
        }
        // GET: PizzaUser
        public ActionResult GetAllUser()
        {
            var data = userRepo.GetAllUser();
            return View(data.ToList());
        }
        public ActionResult GetUserById(int id)
        {
            var data = userRepo.GetUserById(id);
            return View(Models.Mapper.Map(data));
        }
        public ActionResult DeleteUserById(int id)
        {
            userRepo.DeleteUserById(id);
            return RedirectToAction("GetAllUser", "PizzaUser");
        }
        public ActionResult EditUser(int id)
        {
            User data = userRepo.EditUserDetail(id);
            Models.Register reg = new Models.Register()
            {
                id=data.id,
                Name = data.Name,
                Email = data.email,
                Zipcode = data.Zipcode
            };
            return View(reg);
        }
        [HttpPost]
        public ActionResult UpdateDetails(Models.Register reg)
        {
            User obj = new User();
            obj.id = reg.id; obj.Name = reg.Name;
            obj.email = reg.Email; obj.Zipcode = reg.Zipcode;
            
            userRepo.UpdateData(obj);
            return RedirectToAction("GetAllUser", "PizzaUser");
        }
    }
}