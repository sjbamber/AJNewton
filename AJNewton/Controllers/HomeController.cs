using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AJNewton.Models;
using AJNewton.Code;

namespace AJNewton.Controllers
{
    public class HomeController : Controller
    {
        private Mail mail;
        public HomeController()
        {
            mail = new Mail();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel view)
        {
            if (ModelState.IsValid)
            {
                if (mail.SendGeneric(view))
                {
                    ViewBag.MailSent = "Message Sent Successfully";
                }
                else
                {
                    ViewBag.MailSent = "Message Failed to Send";
                }
            }
            return View(view);
        }
    }
}
