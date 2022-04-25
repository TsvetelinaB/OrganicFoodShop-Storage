using System.Collections.Generic;
using System.Linq;

using AutoMapper;

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
                   .Select(c => new ProductCategoryServiceModel
                   {
                       Id = c.Id,
                       Name = c.Name
                   })
                //   .ProjectTo<ProductCategoryServiceModel>(this.mapper)
                   .ToList();
        }
    }
}
