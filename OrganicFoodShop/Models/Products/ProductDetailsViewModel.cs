using System.ComponentModel.DataAnnotations;

using static OrganicFoodShop.Models.DisplayNameConstants;

namespace OrganicFoodShop.Models.Products
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = ProductName)]
        public string Name { get; set; }

        public string Barcode { get; set; }

        [Display(Name = ProductPriceBuy)]
        public decimal PriceBuy { get; set; }

        [Display(Name = ProductPriceSell)]
        public decimal PriceSell { get; set; }

        public int Quantity { get; set; }

        public string Manufacturer { get; set; }

        [Display(Name = ProductCategory)]
        public int CategoryId { get; set; }

        public string Description { get; set; }

        [Display(Name = ProductImageUrl)]
        public string ImageURL { get; set; }
    }
}
