using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using OrganicFoodShop.Data;
using OrganicFoodShop.Models;
using OrganicFoodShop.Models.Products;

namespace OrganicFoodShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopDbContext data;

        public HomeController(ShopDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index()
        {
            var products = data
                 .Products
                 .OrderByDescending(p => p.Id)
                 .Select(p => new ProductListingViewModel
                 {
                     Id = p.Id,
                     Name = p.Name,
                     PriceSell = p.PriceSell,
                     ImageURL = p.ImageURL
                 })
                 .Take(3)
                 .ToList();

            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
