using Microsoft.AspNetCore.Mvc;

namespace OrganicFoodShop.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
