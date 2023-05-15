using Microsoft.AspNetCore.Mvc;

namespace PetShopApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return Content("There was an unexpected error. Please come back later :) ");
            //return RedirectToAction ("HomePage");
            //return view(pop app js);
        }
    }
}
