using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using OrganicFoodShop.Services.Products.Models;

using static OrganicFoodShop.Data.DataConstants.Product;

namespace OrganicFoodShop.Models.Products
{
    public class AddProductFormModel
    {
        [Required(ErrorMessage = "Field '{0}' is required")]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Field '{0}' must be between {2} and {1} symbols")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
        [MaxLength(BarcodeMaxLength)]
        public string Barcode { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
        [Range(0.000, 1_000_000.000, ErrorMessage = "Value of field '{0}' is not acceptable")]
        [Display(Name = "Price Buy")]
        public decimal PriceBuy { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
        [Range(0.000, 1000000.000, ErrorMessage = "Value of field '{0}' is not acceptable")]
        [Display(Name = "Price Sell")]
        public decimal PriceSell { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
        [Range(0, 1_000, ErrorMessage = "Value of field '{0}' is not acceptable")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
        public string Manufacturer { get; set; }

        // public bool IsAvalable { get; set; }
       
        [Required(ErrorMessage = "Field '{0}' is required")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<ProductCategoryServiceModel> Categories { get; set; }  

        [StringLength(DescriptionMaxLength, ErrorMessage = "Field '{0}' must be {1} symbols maximum")]
        public string Description { get; set; }

        [Display(Name = "Image URL")]
        public string ImageURL { get; set; }
    }
}
