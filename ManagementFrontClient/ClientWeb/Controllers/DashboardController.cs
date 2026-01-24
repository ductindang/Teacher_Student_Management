using Microsoft.AspNetCore.Mvc;

namespace ClientWeb.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
