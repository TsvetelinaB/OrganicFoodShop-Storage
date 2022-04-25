using System.Collections.Generic;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OrganicFoodShop.Data;
using OrganicFoodShop.Data.Models;
using OrganicFoodShop.Infrastructure;
using OrganicFoodShop.Models.Products;
using OrganicFoodShop.Services.Employees;
using OrganicFoodShop.Services.Products;

namespace OrganicFoodShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopDbContext data;
        private readonly IMapper mapper;
        private readonly IProductService products;
        private readonly IEmployeeService employees;

        public ProductsController(ShopDbContext data, IMapper mapper, IProductService products, IEmployeeService employees)
        {
            this.data = data;
            this.mapper = mapper;
            this.products = products;
            this.employees = employees;
        }

        [Authorize]
        public IActionResult Add()
        {
            if (this.employees.EmployeeId(this.User.GetId()) == 0)
            {
                return RedirectToAction(nameof(EmployeesController.Register), "Employees");
            }

            return View(new AddProductFormModel
            {                 
                Categories = this.products.AllProductCategories()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddProductFormModel product)
        {
            if (this.employees.EmployeeId(this.User.GetId()) == 0)
            {
                return RedirectToAction(nameof(EmployeesController.Register), "Employees");
            }

            if (!this.data.Categories.Any(c => c.Id == product.CategoryId))
            {
                this.ModelState.AddModelError(nameof(product.CategoryId), "Category does not exist!");
            }

            if (!this.ModelState.IsValid)
            {
                product.Categories = this.products.AllProductCategories();
                return this.View(product);
            }

            var productData = mapper.Map<Product>(product);

            productData.EmployeeId = this.employees.EmployeeId(this.User.GetId());

            this.data.Products.Add(productData);
            this.data.SaveChanges();

            return this.RedirectToAction(nameof(All));
        }

        public IActionResult All([FromQuery] AllProductsQueryModel query, int category)
        {
            var productsQuery = this.data.Products.AsQueryable();

            if (category > 0)
            {
                productsQuery = productsQuery
                    .Where(p =>
                    p.Category.Id == category);
            }

            if (!string.IsNullOrWhiteSpace(query.Manufacturer))
            {
                if (query.Manufacturer != "Select a Manufacturer")
                {
                    productsQuery = productsQuery
                        .Where(p =>
                        p.Manufacturer == query.Manufacturer);
                }
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                productsQuery = productsQuery
                    .Where(p =>
                    p.Barcode.ToLower().Contains(query.SearchTerm.ToLower()) ||
                    p.Description.ToLower().Contains(query.SearchTerm.ToLower()) ||
                    p.Name.ToLower().Contains(query.SearchTerm.ToLower()) ||
                    p.Manufacturer.ToLower().Contains(query.SearchTerm.ToLower()));
            }

            productsQuery = query.Sorting switch
            {
                ProductSorting.PriceAsc => productsQuery.OrderBy(p => p.PriceSell),
                ProductSorting.PriceDesc => productsQuery.OrderByDescending(p => p.PriceSell),
                ProductSorting.DateCreatedAsc => productsQuery.OrderBy(p => p.Id),
                ProductSorting.DateCreatedDesc or _ => productsQuery.OrderByDescending(p => p.Id)
            };

            var products = productsQuery
                .Skip((query.CurrentPage - 1) * AllProductsQueryModel.ProductsPerPage)
                .Take(AllProductsQueryModel.ProductsPerPage)
                .ProjectTo<ProductListingViewModel>(this.mapper.ConfigurationProvider)
                .ToList();

            var totalProducts = productsQuery.Count();

            var productManufacturers = this.data
                .Products
                .Select(p => p.Manufacturer)
                .Distinct()
                .ToList();

            var productCategories = this.products.AllProductCategories();

            return View(new AllProductsQueryModel
            {
                Products = products,
                Categories = productCategories,
                Manufacturers = productManufacturers,
                TotalProducts = totalProducts,
                SearchTerm = query.SearchTerm,
                Sorting = query.Sorting,
                CurrentPage = query.CurrentPage,
                Category = query.Category,
                Manufacturer = query.Manufacturer
            });
        }
    }
}
