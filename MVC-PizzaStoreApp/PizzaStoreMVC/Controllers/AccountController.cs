using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaStoreMVC.Models;
using PizzaRepository.Classes;
using PizzaDbData;
using System.Web.Security;

namespace PizzaStoreMVC.Controllers
{
    public class AccountController : Controller
    {
        private PizzaDb db;
        public AccountController()
        {
            db = new PizzaDb();
        }
        public ActionResult Login()
        {
            Models.Login obj = new Models.Login();
            return View(obj);
        }
        [HttpPost]
        public ActionResult Login(Models.Login obj)
        {
            if (ModelState.IsValid)
            {
                var userData = db.Users.Where(e => e.email == obj.Email).FirstOrDefault();
                if (userData != null)
                {
                    int id = userData.id;
                    var LoginPass = db.Logins.Where(e => e.user_id == id).FirstOrDefault().Password;
                    if (obj.Email == userData.email && LoginPass == obj.Password)
                    {
                        Session["userid"] = userData.id;
                        HttpCookie cookie = new HttpCookie("User_email", (userData.email).ToString());
                        Response.Cookies.Add(cookie);
                        FormsAuthentication.SetAuthCookie(obj.Email, false);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ViewBag.isValid = "Invalid Credentials";
                return View();
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register regObj)
        {
            User obj = new User();
            PizzaDbData.Login log = new PizzaDbData.Login();
            if (ModelState.IsValid)
            {
                obj.Name = regObj.Name;
                obj.email = regObj.Email;
                obj.Gender =regObj.Gender.ToString();
                obj.Zipcode = regObj.Zipcode;
                db.Users.Add(obj);
                db.SaveChanges();
                int id=db.Users.Max(p => p.id);
                log.user_id =id;
                log.Password = regObj.Password;
                db.Logins.Add(log);
                db.SaveChanges();
                return RedirectToAction("GetAllUser","PizzaUser");
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }
    }
}