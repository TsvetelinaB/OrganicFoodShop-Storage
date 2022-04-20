using System.ComponentModel.DataAnnotations;

namespace OrganicFoodShop.Models.Users
{
    public class LoginFormModel
    {
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
