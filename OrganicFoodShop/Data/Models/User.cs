using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;

using static OrganicFoodShop.Data.DataConstants.User;

namespace OrganicFoodShop.Data.Models
{
    public class User : IdentityUser
    {
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; }
    }
}
