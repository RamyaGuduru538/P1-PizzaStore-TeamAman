using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PizzaDbData;
using PizzaStoreMVC.Models;

namespace PizzaStoreMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            ContactUs contactUs = new ContactUs();
            return View();
        }
        [Authorize]
        [HttpPost]

        [ValidateAntiForgeryToken]
        public  ActionResult Contact(ContactUs model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                // string sender = "<p>{0}";
                message.To.Add(new MailAddress("storepizza281@gmail.com")); //replace with valid value
                message.Subject = "Pizza User Contact";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    smtp.Send(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }
        [Authorize]
        public ActionResult Sent()
        {
            return View();
        }
    }
}