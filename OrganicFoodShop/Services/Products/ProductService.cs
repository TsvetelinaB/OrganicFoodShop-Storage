using System.Collections.Generic;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using OrganicFoodShop.Data;
using OrganicFoodShop.Data.Models;
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
            var productData = mapper.Map<Product>(product);
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
