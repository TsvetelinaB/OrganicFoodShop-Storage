using System.Collections.Generic;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using OrganicFoodShop.Data;
using OrganicFoodShop.Services.Products.Models;

namespace OrganicFoodShop.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly ShopDbContext data;
        private readonly IConfigurationProvider mapper;

        public ProductService(ShopDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper.ConfigurationProvider;
        }

        public IEnumerable<ProductCategoryServiceModel> AllProductCategories()
        {
            return this.data
                   .Categories
                   .ProjectTo<ProductCategoryServiceModel>(this.mapper)
                   .ToList();
        }
    }
}
