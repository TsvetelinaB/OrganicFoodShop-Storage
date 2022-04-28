using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

using static OrganicFoodShop.Data.DataConstants.Product;

namespace OrganicFoodShop.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MinLength (NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(BarcodeMaxLength)]
        public string Barcode { get; set; }

        [Column(TypeName = "decimal(9, 3)")]
        public decimal PriceBuy { get; set; }

        [Column(TypeName = "decimal(9, 3)")]
        public decimal PriceSell { get; set; }

        public int Quantity { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        public bool IsDeleted { get; set; }       

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public string ImageURL { get; set; }

        public int? EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
