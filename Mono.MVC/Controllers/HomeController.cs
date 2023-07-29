using Microsoft.AspNetCore.Mvc;

namespace Mono.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult DeleteConfirmation(int id)
        {
            ViewBag.ItemId = id;
            return View();
        }
    }
}
