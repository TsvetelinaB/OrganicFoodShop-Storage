using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using OrganicFoodShop.Services.Products.Models;

using static OrganicFoodShop.Data.DataConstants.Product;
using static OrganicFoodShop.Models.ErrorMessages;
using static OrganicFoodShop.Models.DisplayNameConstants;

namespace OrganicFoodShop.Models.Products
{
    public class AddProductFormModel
    {
        [Required(ErrorMessage = FieldRequired)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = SymbolsCount)]
        [Display(Name = ProductName)]
        public string Name { get; set; }

        [Required(ErrorMessage = FieldRequired)]
        [MaxLength(BarcodeMaxLength)]
        public string Barcode { get; set; }

        [Required(ErrorMessage = FieldRequired)]
        [Range(0.000, 1_000_000.000, ErrorMessage = ValueNotAcceptable)]
        [Display(Name = ProductPriceBuy)]
        public decimal PriceBuy { get; set; }

        [Required(ErrorMessage = FieldRequired)]
        [Range(0.000, 1000000.000, ErrorMessage = ValueNotAcceptable)]
        [Display(Name = ProductPriceSell)]
        public decimal PriceSell { get; set; }

        [Required(ErrorMessage = FieldRequired)]
        [Range(0, 1_000, ErrorMessage = ValueNotAcceptable)]
        public int Quantity { get; set; }

        [Required(ErrorMessage = FieldRequired)]
        public string Manufacturer { get; set; }

        // public bool IsAvalable { get; set; }
       
        [Required(ErrorMessage = FieldRequired)]
        [Display(Name = ProductCategory)]
        public int CategoryId { get; set; }

        public IEnumerable<ProductCategoryServiceModel> Categories { get; set; }  

        [StringLength(DescriptionMaxLength, ErrorMessage = SymbolsMax)]
        public string Description { get; set; }

        [Display(Name = ProductImageUrl)]
        public string ImageURL { get; set; }
    }
}
