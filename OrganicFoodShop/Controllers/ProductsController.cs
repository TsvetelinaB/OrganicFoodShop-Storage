using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OrganicFoodShop.Infrastructure;
using OrganicFoodShop.Models.Products;
using OrganicFoodShop.Services.Employees;
using OrganicFoodShop.Services.Products;
using OrganicFoodShop.Services.Products.Models;

namespace OrganicFoodShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IProductService products;
        private readonly IEmployeeService employees;

        public ProductsController(IMapper mapper, IProductService products, IEmployeeService employees)
        {
            this.mapper = mapper;
            this.products = products;
            this.employees = employees;
        }

        [Authorize]
        public IActionResult Add()
        {
            if (!this.employees.IsEmployee(this.User.GetId()))
            {
                return this.RedirectToAction(nameof(EmployeesController.Register), "Employees");
            }

            return this.View(new AddProductFormModel
            {
                Categories = this.products.AllProductCategories()
            });
        }

        [HttpPost]
        [Authorize]
        [AutoValidateAntiforgeryToken]
        public IActionResult Add(AddProductFormModel product)
        {
            if (!this.employees.IsEmployee(this.User.GetId()))
            {
                return this.RedirectToAction(nameof(EmployeesController.Register), "Employees");
            }

            if (!this.products.IsValidCategory(product.CategoryId))
            {
                this.ModelState.AddModelError(nameof(product.CategoryId), "Category does not exist!");
            }

            if (!this.ModelState.IsValid)
            {
                product.Categories = this.products.AllProductCategories();
                return this.View(product);
            }

            var productData = mapper.Map<AddProductServiceModel>(product);

            var employeeId = this.employees.EmployeeId(this.User.GetId());

            this.products.Add(productData, employeeId);

            return View("Added");
        }

        public IActionResult All([FromQuery] AllProductsQueryModel query, int category)
        {
            var products = this.products.All(query, category);

            return this.View(products);
        }

        public IActionResult Details(int id)
        {
            var product = this.products.Details(id);

            if (product == null)
            {
                return NotFound();
            }

            return this.View(product);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            if (!this.employees.IsEmployee(this.User.GetId()))
            {
                return this.RedirectToAction(nameof(EmployeesController.Register), "Employees");
            }

            var product = this.products.Details(id);

            var productFormData = this.mapper.Map<AddProductFormModel>(product);

            productFormData.Categories = this.products.AllProductCategories();

            return View(productFormData);
        }

        [HttpPost]
        [Authorize]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, AddProductFormModel product)
        {

            if (!this.employees.IsEmployee(this.User.GetId()))
            {
                return this.RedirectToAction(nameof(EmployeesController.Register), "Employees");
            }

            if (!this.products.IsValidCategory(product.CategoryId))
            {
                this.ModelState.AddModelError(nameof(product.CategoryId), "Category does not exist!");
            }

            if (!this.ModelState.IsValid)
            {
                product.Categories = this.products.AllProductCategories();
                return this.View(product);
            }

            var editedProduct = this.products.Edit(product, id);

            if (!editedProduct)
            {
                return BadRequest();
            }

            return View("Edited");
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            if (!this.products.Delete(id))
            {
                return BadRequest();
            }

            return this.View();
        }
    }
}
