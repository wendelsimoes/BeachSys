using Microsoft.AspNetCore.Mvc;

namespace BeachSys.Controllers
{
    public class AdminController : Controller
    {
        public AdminController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}