using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OrganicFoodShop.Models.Products
{
    public class AllProductsQueryModel
    {
        [Display(Name = "")]
        public string Manufacturer { get; set; }

        public IEnumerable<string> Manufacturers { get; set; }

        [Display(Name = "")]
        public string Category { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }

        [Display(Name = "Search")]
        public string SearchTerm { get; set; }

        public ProductSorting Sorting { get; set; }

        public IEnumerable<ProductListingViewModel> Products { get; set; }
    }
}
