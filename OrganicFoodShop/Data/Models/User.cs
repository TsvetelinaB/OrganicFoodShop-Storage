using Microsoft.AspNetCore.Identity;



namespace OrganicFoodShop.Data.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}
