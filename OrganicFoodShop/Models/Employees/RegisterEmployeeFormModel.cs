using System.ComponentModel.DataAnnotations;

using static OrganicFoodShop.Data.DataConstants.Employee;
using static OrganicFoodShop.Models.ErrorMessages;
using static OrganicFoodShop.Models.DisplayNameConstants;

namespace OrganicFoodShop.Models.Employees
{
    public class RegisterEmployeeFormModel
    {
        [Required(ErrorMessage = FieldRequired)]
        [StringLength(FullNameMaxLength, MinimumLength = FullNameMinLength, ErrorMessage = SymbolsCount)]
        [Display(Name = EmployeeFullName)]
        public string FullName { get; set; }


        [Required(ErrorMessage = FieldRequired)]
        [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength, ErrorMessage = SymbolsCount)]
        public string Username { get; set; }

        // [Range(YearMinValue, YearMaxValue)]
        //[Display(Name = "Date Employed")]
        //public int DateEmployed { get; set; }
    }
}
