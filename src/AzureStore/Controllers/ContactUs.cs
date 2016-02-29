using AzureStore.Models;
using AzureStore.Services;
using Microsoft.AspNet.Mvc;

namespace AzureStore.Controllers
{
    public class ContactUs : Controller
    {
        private IContactUs _contactUs;

        public ContactUs(IContactUs contactUs)
        {
            _contactUs = contactUs;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactUsForm model)
        {
            _contactUs.SubmitDetails(model.CustomerEmail, model.CustomerName, model.Message);
            return RedirectToAction("Index");
        }
    }  
}
