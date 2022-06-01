using System.Collections.Generic;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.AspNetCore.Mvc;

using OrganicFoodShop.Data;
using OrganicFoodShop.Models.Products;
using OrganicFoodShop.Services.Products.Models;

namespace OrganicFoodShop.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly ShopDbContext data;
        private readonly IMapper mapper;

        public ProductService(ShopDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public void Add(AddProductServiceModel product, int employeeId)
        {
            var newProductData = mapper.Map<Data.Models.Product>(product);
            newProductData.EmployeeId = employeeId;

            var productExists = this.data.Products.Any(p => p.Barcode == newProductData.Barcode);

            if (!productExists)
            {
                this.data.Add(newProductData);
                this.data.SaveChanges();
            }

            else
            {
                var productInDb = this.data.Products
                    .Where(p => p.Barcode == newProductData.Barcode)
                    .FirstOrDefault();

                productInDb.Quantity += newProductData.Quantity;

                this.data.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            var product = this.data.Products
                .Where(p => p.Id == id)
                .FirstOrDefault();

            if (product == null)
            {
                return false;
            }
            
            product.IsDeleted = true; 

            this.data.SaveChanges();

            return true;
        }

        public bool Edit(AddProductFormModel product, int id)
        {
            var productExists = this.data.Products.Any(p => p.Id == id);

            if (!productExists)
            {
                return false;
            }

            var productInDb = this.data.Products.Find(id);

            productInDb.Name = product.Name;
            productInDb.Barcode = product.Barcode;
            productInDb.PriceBuy = product.PriceBuy;
            productInDb.PriceSell = product.PriceSell;
            productInDb.CategoryId = product.CategoryId;
            productInDb.Description = product.Description;
            productInDb.Manufacturer = product.Manufacturer;
            productInDb.ImageURL = product.ImageURL;
            productInDb.Quantity = product.Quantity;

            this.data.SaveChanges();

            return true;
        }

        public ProductDetailsViewModel Details(int id)
        {
            var product = this.data
                .Products
                .Where(p => p.Id == id)
                .ProjectTo<ProductDetailsViewModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();

            return product;
        }       

        public AllProductsQueryModel All([FromQuery] AllProductsQueryModel query, int category)
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
                .Where(p => p.IsDeleted == false)
                .Skip((query.CurrentPage - 1) * AllProductsQueryModel.ProductsPerPage)
                .Take(AllProductsQueryModel.ProductsPerPage)
                .ProjectTo<ProductListingViewModel>(this.mapper.ConfigurationProvider)
                .ToList();

            var totalProducts = productsQuery
                .Where (p => p.IsDeleted == false)
                .Count();

            var productManufacturers = this.data
                .Products
                .Select(p => p.Manufacturer)
                .Distinct()
                .ToList();

            var productCategories = AllProductCategories();

            return new AllProductsQueryModel
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
            };
        }

        public IEnumerable<ProductDetailsViewModel> AllApiProducts()
        {
            var allProducts = this.data.Products
                .ProjectTo<ProductDetailsViewModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return allProducts;
        }

        public IEnumerable<ProductListingViewModel> NewestThreeProducts()
        {
            var products = data
                 .Products
                 .Where(p => p.IsDeleted == false)
                 .OrderByDescending(p => p.Id)
                 .ProjectTo<ProductListingViewModel>(this.mapper.ConfigurationProvider)
                 .Take(3)
                 .ToList();

            return products;
        }

        public bool IsValidCategory(int categoryId)
        {
            return this.data
                   .Categories
                   .Any(c => c.Id == categoryId);
        }

        public IEnumerable<ProductCategoryServiceModel> AllProductCategories()
        {
            return this.data
                   .Categories
                   .ProjectTo<ProductCategoryServiceModel>(this.mapper.ConfigurationProvider)
                   .ToList();
        }
    }
}
