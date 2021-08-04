using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using PanDelivery.Models;
using MyInventory.Models;

namespace MyInventory.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Contact record)
        {
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress("testentprog@gmail.com", record.SenderName)
            };
            mail.To.Add(new MailAddress(record.Email));
            mail.Subject = record.Subject;
            mail.Body = record.Message;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;


            using System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("testentprog@gmail.com", "Potato123@"),
                EnableSsl = true
            };

            smtp.Send(mail);
            ViewBag.Message = "Inquiry Sent!";
            return View();
        }
    }
}

