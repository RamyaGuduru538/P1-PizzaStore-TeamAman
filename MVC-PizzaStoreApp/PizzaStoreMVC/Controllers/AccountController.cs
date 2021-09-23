using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaStoreMVC.Models;
using PizzaRepository.Classes;
using PizzaDbData;
using System.Web.Security;
using System.Net;

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
                        HttpCookie cookie = new HttpCookie("User_email", (userData.Name).ToString());
                        HttpCookie cookie1 = new HttpCookie("User_id", (userData.id).ToString());

                        Response.Cookies.Add(cookie);
                        Response.Cookies.Add(cookie1);

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
            var c = new HttpCookie("User_email")
            {
                Expires = DateTime.Now.AddDays(-1)
            };
            var c1 = new HttpCookie("User_id")
            {
                Expires = DateTime.Now.AddDays(-1)
            };
            Response.Cookies.Add(c);
            Response.Cookies.Add(c1);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(Models.ForgotPassword forgot)
        {
            if (ModelState.IsValid)
            {
                int user_id = db.Users.Include("Logins").Where(u => u.email == forgot.Email).Select(u => u.id).FirstOrDefault();
                if (user_id > 0)
                {
                    PizzaDbData.Login loginData = db.Logins.Where(p => p.user_id == user_id).FirstOrDefault();
                    loginData.Password = forgot.Password;
                    db.SaveChanges();
                    return RedirectToAction("Login","Account");
                }
                TempData["Message"] = "No Record Found with this Email";
                TempData["color"] = "red";
                return View();
            }
            return View();
        }
    }
}