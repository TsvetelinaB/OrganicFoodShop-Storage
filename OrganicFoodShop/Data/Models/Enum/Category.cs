using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using static OrganicFoodShop.Data.DataConstants;

namespace OrganicFoodShop.Data.Models
{
    public enum Category
    {
        Superfoods = 1,
        [Display(Name = "Grains, Seeds, Nuts, Fruits")] GrainsSeedsNutsFruits = 2,
        [Display(Name = "Oils, Spreads, Jams")] OilsSpreadsJams = 3,
        [Display(Name = "Coffee, Tea")] CoffeeTea = 4,
        [Display(Name = "Chocolates, Desserts")] ChocolatesDesserts = 5,
        [Display(Name = "Nutritional Supplements")] NutritionalSupplements = 6,
        Drinks = 7,
        Cosmetics = 8
    }
}
