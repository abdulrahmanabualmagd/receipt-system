using Microsoft.AspNetCore.Mvc;

namespace MVC_Core.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
