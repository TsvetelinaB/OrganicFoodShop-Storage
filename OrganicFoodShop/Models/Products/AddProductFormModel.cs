using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

using OrganicFoodShop.Data.Models;

using static OrganicFoodShop.Data.DataConstants;

namespace OrganicFoodShop.Models.Products
{
    public class AddProductFormModel
    {
        //public int Id { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
        [StringLength(ProductNameMaxLength, ErrorMessage = "Field '{0}' must be between {2} and {1} symbols", MinimumLength = ProductNameMinLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
        [MaxLength(ProductBarcodeMaxLength)]
        public string Barcode { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
       // [Range(0.000, 1_000_000.000, ErrorMessage = "Value of field '{0}' is not acceptable")]
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

        // public int CategoryId { get; set; }
        
        [Required(ErrorMessage = "Option in field '{0}' is required to be selected")]
        public Category Category { get; set; }

        [StringLength(ProductDescriptionMaxLength, ErrorMessage = "Field '{0}' must be {1} symbols maximum")]
        public string Description { get; set; }

        [Display(Name = "Image URL")]
        public string ImageURL { get; set; }
    }
}
