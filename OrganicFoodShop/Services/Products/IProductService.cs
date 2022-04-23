using System.Collections.Generic;

using OrganicFoodShop.Services.Products.Models;

namespace OrganicFoodShop.Services.Products
{
    public interface IProductService
    {
        IEnumerable<ProductCategoryServiceModel> AllProductCategories();
    }
}
