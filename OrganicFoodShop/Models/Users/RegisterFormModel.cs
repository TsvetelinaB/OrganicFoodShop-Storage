using System.ComponentModel.DataAnnotations;

namespace OrganicFoodShop.Models.Users
{
    public class RegisterFormModel
    {
        [Required (ErrorMessage = "Field '{0}' is required")]
        [Display(Name ="E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
        // [StringLength(ProductNameMaxLength, ErrorMessage = "Field '{0}' must be between {2} and {1} symbols", MinimumLength = ProductNameMinLength)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
