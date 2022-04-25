using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using OrganicFoodShop.Data;
using OrganicFoodShop.Services.Products.Models;

namespace OrganicFoodShop.Models.Products
{
    public class AllProductsQueryModel
    {
        [Display (Name = "")]
        public string Manufacturer { get; set; }

        public IEnumerable<string> Manufacturers { get; set; }

        [Display(Name = "Filter")]
        public string Category { get; set; }

        public IEnumerable<ProductCategoryServiceModel> Categories { get; set; }

        [Display(Name = "Search")]
        public string SearchTerm { get; set; }

        [Display(Name = "Sort")]
        public ProductSorting Sorting { get; set; }

        public const int ProductsPerPage = GlobalConstants.ProductsPerPage;

        public int CurrentPage { get; set; } = GlobalConstants.DefaultPageNumber;

        public int TotalProducts{ get; set; }

        public IEnumerable<ProductListingViewModel> Products { get; set; }
    }
}
