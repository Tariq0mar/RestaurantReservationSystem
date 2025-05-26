using Microsoft.AspNetCore.Mvc;

namespace RestaurantReservationSystem.Controllers
{
    public class MenuItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
