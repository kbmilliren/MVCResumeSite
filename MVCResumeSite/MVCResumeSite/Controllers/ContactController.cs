using MVCResumeSite.Models;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MVCResumeSite.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContactMessage Form)
        {
            var MyAddresss = ConfigurationManager.AppSettings["ContactEmail"];
            var MyUsername = ConfigurationManager.AppSettings["Username"];
            var MyPassword = ConfigurationManager.AppSettings["Password"];

            if(ModelState.IsValid)
            {
                SendGridMessage mail = new SendGridMessage();
                mail.From = new MailAddress(Form.FromEmail);
                mail.AddTo(MyAddresss);
                mail.Subject = Form.Name;
                mail.Text = Form.Message;

                var credentials = new NetworkCredential(MyUsername, MyPassword);
                var transportWeb = new Web(credentials);
                transportWeb.Deliver(mail);
            }
            return View();
        }
    }
}