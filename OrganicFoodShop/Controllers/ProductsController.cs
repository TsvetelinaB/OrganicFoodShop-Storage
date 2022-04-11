using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.AspNetCore.Mvc;

using OrganicFoodShop.Data;
using OrganicFoodShop.Data.Models;
using OrganicFoodShop.Models.Products;

namespace OrganicFoodShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopDbContext data;
        private readonly IMapper mapper;

        public ProductsController(ShopDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public IActionResult Add()
        {
            return this.View(new AddProductFormModel
            {
                Categories = this.GetProductCategories()
            });
        }

        [HttpPost]
        public IActionResult Add(AddProductFormModel product)
        {
            if (!this.data.Categories.Any(c => c.Id == product.CategoryId))
            {
                this.ModelState.AddModelError(nameof(product.CategoryId), "Category does not exist!");
            }

            if (!this.ModelState.IsValid)
            {
                product.Categories = this.GetProductCategories();

                return this.View(product);
            }

            var productData = mapper.Map<Product>(product);
                
            //    new Product{
            //    ImageURL = product.ImageURL,
            //    PriceBuy = product.PriceBuy,
            //    PriceSell = product.PriceSell,
            //    Barcode = product.Barcode,
            //    CategoryId = product.CategoryId,                 
            //    Description = product.Description,
            //    Manufacturer = product.Manufacturer,
            //    Quantity = product.Quantity,
            //    Name = product.Name
            //};

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
                .ProjectTo<ProductListingViewModel>(this.mapper.ConfigurationProvider)
                //.Select(p => new ProductListingViewModel
                //{
                //    Id = p.Id,
                //    Name = p.Name,
                //    PriceSell = p.PriceSell,
                //    ImageURL = p.ImageURL
                //})
                .ToList();

            return this.View(products);
        }
    }
}
