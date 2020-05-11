using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using James_MVC.Models;
using System.Collections.Generic;

namespace James_MVC.Controllers
{
    public class HomeController : Controller
    {
        //Email code courtesy of https://nickolasfisher.com/blog/How-To-Make-a-Basic-Working-Contact-Form-With-ASP-NET-Core-MVC-and-MailKit

        private EmailAddress FromAndToEmailAddress;
        private IEmailService EmailService;
        public HomeController(EmailAddress _fromAddress, IEmailService _emailService)
        {
            FromAndToEmailAddress = _fromAddress;
            EmailService = _emailService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                EmailMessage msgToSend = new EmailMessage
                {
                    FromAddresses = new List<EmailAddress> { FromAndToEmailAddress },
                    ToAddresses = new List<EmailAddress> { FromAndToEmailAddress },
                    Content = $"Name: {model.Name} " + "<br/>" +
                              $"Email: {model.Email} " + "<br/>" +
                              $"Message: {model.Message}",
                    Subject = "Contact Form - MVC Site"
                };

                EmailService.Send(msgToSend);
                return RedirectToAction("ContactThanks");
            }
            else
            {
                return Index();
            }

        }


        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult ContactThanks()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}