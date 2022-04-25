using System.Collections.Generic;

using OrganicFoodShop.Services.Products.Models;

namespace OrganicFoodShop.Services.Products
{
    public interface IProductService
    {
        void Add(AddProductServiceModel product, int employeeId);

        bool IsValidCategory(int categoryId);

        IEnumerable<ProductCategoryServiceModel> AllProductCategories();
    }
}
