using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using OrganicFoodShop.Services.Products.Models;

using static OrganicFoodShop.Models.GlobalConstants;
using static OrganicFoodShop.Models.DisplayNameConstants;

namespace OrganicFoodShop.Models.Products
{
    public class AllProductsQueryModel
    {
        [Display (Name = AllProductsManufacturer)]
        public string Manufacturer { get; set; }

        public IEnumerable<string> Manufacturers { get; set; }

        [Display(Name = AllProductsCategory)]
        public string Category { get; set; }

        public IEnumerable<ProductCategoryServiceModel> Categories { get; set; }

        [Display(Name = AllProductsSearchTerm)]
        public string SearchTerm { get; set; }

        [Display(Name = AllProductsSorting)]
        public ProductSorting Sorting { get; set; }

        public const int ProductsPerPage = GlobalConstants.ProductsPerPage;

        public int CurrentPage { get; set; } = DefaultPageNumber;

        public int TotalProducts{ get; set; }

        public IEnumerable<ProductListingViewModel> Products { get; set; }
    }
}
