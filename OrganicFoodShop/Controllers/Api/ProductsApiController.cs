using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using OrganicFoodShop.Models.Products;
using OrganicFoodShop.Services.Products;

namespace OrganicFoodShop.Controllers.Api
{
    [ApiController]
    [Route("api/products")]
    public class ProductsApiController : ControllerBase
    {
        private readonly IProductService products;

        public ProductsApiController(IProductService products)
        {
            this.products = products;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDetailsViewModel>> AllProducts()
        {
            var allPproducts = this.products.AllApiProducts();

            if (allPproducts == null)
            {
                return NotFound();
            }

            return Ok(allPproducts);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            var productData = this.products.Details(id);

            if (productData == null)
            {
                return NotFound();
            }

            return Ok(productData);
        }
    }
}
