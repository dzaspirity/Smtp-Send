using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using SmtpSend.Models;

namespace SmtpSend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ActionName(nameof(Index))]
        [HttpPost]
        public async Task<ActionResult> IndexPost(SendMessageModel model)
        {
            ViewBag.ShowSuccess = false;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var smtpClient = new SmtpClient(model.SmtpHost, model.SmtpPort)
            {
                Credentials = new NetworkCredential(model.UserName, model.Password)
            };

            var mailMessage = new MailMessage(model.EmailFrom, model.EmailTo)
            {
                Body = model.Body,
                Subject = model.Subject,
                IsBodyHtml = false
            };

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
                ViewBag.ShowSuccess = true;
            }
            catch (Exception exc)
            {
                ModelState.AddModelError(nameof(model.SmtpHost), exc);
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}