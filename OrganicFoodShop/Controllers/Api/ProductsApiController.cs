using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using OrganicFoodShop.Data;
using OrganicFoodShop.Data.Models;

namespace OrganicFoodShop.Controllers.Api
{
    [ApiController]
    [Route("api/products")]
    public class ProductsApiController : ControllerBase
    {
        private readonly ShopDbContext data;

        public ProductsApiController(ShopDbContext data)
        {
            this.data = data;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> AllProducts()
        {
            var products = this.data.Products.ToList();

            if(!products.Any())
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            var product = this.data.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
