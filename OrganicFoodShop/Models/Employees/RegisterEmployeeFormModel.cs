using System.ComponentModel.DataAnnotations;

using static OrganicFoodShop.Data.DataConstants.Employee;

namespace OrganicFoodShop.Models.Employees
{
    public class RegisterEmployeeFormModel
    {
        [Required(ErrorMessage = "Field '{0}' is required")]
        [StringLength(FullNameMaxLength, MinimumLength = FullNameMinLength, ErrorMessage = "Field '{0}' must be between {2} and {1} symbols")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "Field '{0}' is required")]
        [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength, ErrorMessage = "Field '{0}' must be between {2} and {1} symbols")]
        public string Username { get; set; }

        // [Range(YearMinValue, YearMaxValue)]
        //[Display(Name = "Date Employed")]
        //public int DateEmployed { get; set; }
    }
}
