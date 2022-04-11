using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

using static OrganicFoodShop.Data.DataConstants;

namespace OrganicFoodShop.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        public string Barcode { get; set; }

        [Column(TypeName = "decimal(9, 3)")]
        public decimal PriceBuy { get; set; }

        [Column(TypeName = "decimal(9, 3)")]
        public decimal PriceSell { get; set; }

        public int Quantity { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        //public bool IsAvalable { get; set; }       

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [MaxLength(ProductDescriptionMaxLength)]
        public string Description { get; set; }

        public string ImageURL { get; set; }
    }
}
