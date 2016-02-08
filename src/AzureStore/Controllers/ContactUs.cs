using AzureStore.Models;
using AzureStore.Services;
using Microsoft.AspNet.Mvc;

namespace AzureStore.Controllers
{
    public class ContactUs : Controller
    {
        private IEmailSender _emailSender;

        public ContactUs(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactUsForm model)
        {
            _emailSender.Send(model.CustomerEmail, model.CustomerName, model.Message);
            return RedirectToAction("Index");
        }
    }

  
}
