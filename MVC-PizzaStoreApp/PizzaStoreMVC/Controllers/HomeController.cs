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
        [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.UserName = TempData["email"];
            ViewBag.btnText = TempData["btnText"];
            ViewBag.btnLink = TempData["btnLink"];
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ContactUs contactUs = new ContactUs();
            return View();
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(ContactUs model)
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

        public ActionResult Sent()
        {
            return View();
        }
    }
}