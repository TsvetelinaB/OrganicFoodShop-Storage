using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using OrganicFoodShop.Models.Products;
using OrganicFoodShop.Services.Products.Models;

namespace OrganicFoodShop.Services.Products
{
    public interface IProductService
    {
        IEnumerable<ProductListingViewModel> NewestThreeProducts();

        AllProductsQueryModel All([FromQuery] AllProductsQueryModel query, int category);
        
        void Add(AddProductServiceModel product, int employeeId);

        bool IsValidCategory(int categoryId);

        IEnumerable<ProductCategoryServiceModel> AllProductCategories();
    }
}
