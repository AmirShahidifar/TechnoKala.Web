using Microsoft.AspNetCore.Mvc;

namespace TechnoKala.Areas.Panel.Controllers
{
    public class HomeController : Controller
    {
        [Area("Panel")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
