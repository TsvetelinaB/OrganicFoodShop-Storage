using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OrganicFoodShop.Models.Products
{
    public enum ProductSorting
    {
        DateCreatedDesc = 0,
        DateCreatedAsc = 1,
        PriceDesc = 2,
        PriceAsc = 3 
    }
}
