using System.Collections.Generic;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.AspNetCore.Mvc;

using OrganicFoodShop.Data;
using OrganicFoodShop.Data.Models;
using OrganicFoodShop.Models.Products;
using OrganicFoodShop.Services.Products.Models;

using static OrganicFoodShop.Data.DataConstants;

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

        public void Add(AddProductServiceModel product, int employeeId)
        {
            var productData = mapper.Map<Data.Models.Product>(product);
            productData.EmployeeId = employeeId;

            this.data.Add(productData);
            this.data.SaveChanges();
        }

        public IEnumerable<ProductCategoryServiceModel> AllProductCategories()
        {
            return this.data
                   .Categories
                   .ProjectTo<ProductCategoryServiceModel>(this.mapper.ConfigurationProvider)
                   .ToList();
        }

        public bool IsValidCategory(int categoryId)
        {
            return this.data
                   .Categories
                   .Any(c => c.Id == categoryId);
        }
    }
}
