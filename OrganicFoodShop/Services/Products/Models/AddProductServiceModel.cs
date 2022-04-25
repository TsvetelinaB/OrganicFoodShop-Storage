namespace OrganicFoodShop.Services.Products.Models
{
    public class AddProductServiceModel
    {
        public string Name { get; set; }

        public string Barcode { get; set; }

        public decimal PriceBuy { get; set; }

        public decimal PriceSell { get; set; }

        public int Quantity { get; set; }

        public string Manufacturer { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }
    }
}
