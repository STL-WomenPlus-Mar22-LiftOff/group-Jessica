using Microsoft.AspNetCore.Mvc;

namespace HouseholdManager.Models.Communications
{
    public class MissionReminderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
