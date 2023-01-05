using Microsoft.AspNetCore.Mvc;

namespace HouseholdManager.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
