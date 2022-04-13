using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicFoodShop.Models.Products
{
    public class ProductListingViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal PriceSell { get; set; }

        public string ImageURL { get; set; }
    }
}
