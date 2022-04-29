using Microsoft.AspNetCore.Mvc;

using OrganicFoodShop.Services.Products;

namespace OrganicFoodShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService products;
       
        public HomeController(IProductService products)
        {
            this.products = products;
        }

        public IActionResult Index()
        {
            return View(this.products.NewestThreeProducts());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
