using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static OrganicFoodShop.Data.DataConstants.Employee;

namespace OrganicFoodShop.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MinLength(UsernameMinLength)]
        [MaxLength(UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [MinLength (PositionMinLength)]
        [MaxLength(PositionMaxLength)]
        public string Position { get; set; }

        [Required]
        public string UserId { get; set; }

        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
