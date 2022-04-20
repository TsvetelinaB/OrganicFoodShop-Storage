using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static OrganicFoodShop.Data.DataConstants.Category;

namespace OrganicFoodShop.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public IEnumerable<Product> Products { get; set; } = new List<Product>();    
    }
}
