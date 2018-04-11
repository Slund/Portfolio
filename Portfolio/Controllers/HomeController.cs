using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portfolio.ViewModels;
using System.Net.Mail;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HandleForm()
        {
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult HandleForm(ContactForm model)
        {
            if (!ModelState.IsValid) { 
                TempData["fail"] = true;
                return View("Index", model);
            }
            else
            { 
                MailMessage message = new MailMessage();
                message.To.Add("slundmain@gmail.com");
                message.Subject = "Besked fra SRLund.dk";
                message.From = new MailAddress(model.Email, model.Name);
                message.Body = "Besked: " + model.Message + " Tlf.:" + model.Phone + " Email: " + model.Email;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("supernemathuske@gmail.com", "Hejumbraco123");
                    smtp.EnableSsl = true;
                    // send mail
                    smtp.Send(message);
                }

                TempData["success"] = true;
                return RedirectToAction("Index");
            }
        }
    }
}