using System.Collections.Generic;

using OrganicFoodShop.Data;
using OrganicFoodShop.Models.Products;

namespace OrganicFoodShop.Services.Products.Models
{
    public class AllProductsQueryServiceModel
    {
        public string Manufacturer { get; set; }

        public IEnumerable<string> Manufacturers { get; set; }

        public string Category { get; set; }

        public IEnumerable<ProductCategoryServiceModel> Categories { get; set; }

        public string SearchTerm { get; set; }

        public ProductSorting Sorting { get; set; }

        public const int ProductsPerPage = GlobalConstants.ProductsPerPage;

        public int CurrentPage { get; set; } = GlobalConstants.DefaultPageNumber;

        public int TotalProducts { get; set; }

        public IEnumerable<ProductListingViewModel> Products { get; set; }
    }
}
