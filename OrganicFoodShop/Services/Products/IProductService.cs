using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using OrganicFoodShop.Models.Products;
using OrganicFoodShop.Services.Products.Models;

namespace OrganicFoodShop.Services.Products
{
    public interface IProductService
    {     
        void Add(AddProductServiceModel product, int employeeId);

        bool Edit(AddProductFormModel product, int id);

        bool Delete(int id);

        ProductDetailsViewModel Details(int id);

        AllProductsQueryModel All([FromQuery] AllProductsQueryModel query, int category);

        IEnumerable<ProductListingViewModel> NewestThreeProducts();

        bool IsValidCategory(int categoryId);

        IEnumerable<ProductCategoryServiceModel> AllProductCategories();
    }
}
