using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using OrganicFoodShop.Data;
using OrganicFoodShop.Data.Models;
using OrganicFoodShop.Models.Products;

namespace OrganicFoodShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopDbContext data;

        public ProductsController(ShopDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add()
        {
            //return this.View();

            return this.View(new AddProductFormModel
            {
                Categories = this.GetProductCategories()
            });
        }

        [HttpPost]
        public IActionResult Add(AddProductFormModel product)
        {
           //    if(!this.data.ca)

            if (!this.ModelState.IsValid)
            {
                product.Categories = this.GetProductCategories();
                return this.View(product); 
                //return this.RedirectToAction(nameof(Add));
            }

            var productData = new Product
            {
                ImageURL = product.ImageURL,
                PriceBuy = product.PriceBuy,
                PriceSell = product.PriceSell,
                Barcode = product.Barcode,
              //  Category = product.Category,
                Description = product.Description,
                Manufacturer = product.Manufacturer,
                Quantity = product.Quantity,
                Name = product.Name
            };

            this.data.Add(productData);
            this.data.SaveChanges();

            // return this.View();
            // ВИНАГИ redirektvame, a ne vryshtam view, zashtoto user-a ako dade refresh na zqvkata, shte se izprati formata otnovo
            return this.RedirectToAction(nameof(All));
        }

        private IEnumerable<CategoryViewModel> GetProductCategories()
        {
            return this.data
                    .Categories
                    .Select(c => new CategoryViewModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .ToList();
        }

        public IActionResult All()
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
                .ToList();

            return this.View(products);
        }
    }
}
