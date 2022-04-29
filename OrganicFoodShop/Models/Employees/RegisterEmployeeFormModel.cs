using System.ComponentModel.DataAnnotations;

using static OrganicFoodShop.Data.DataConstants.Employee;
using static OrganicFoodShop.Models.ErrorMessages;

namespace OrganicFoodShop.Models.Employees
{
    public class RegisterEmployeeFormModel
    {
        [Required(ErrorMessage = FieldRequired)]
        [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength, ErrorMessage = SymbolsCount)]
        public string Username { get; set; }

        [Required(ErrorMessage = FieldRequired)]
        [StringLength(PositionMaxLength, MinimumLength = PositionMinLength, ErrorMessage = SymbolsCount)]
        public string Position { get; set; }
    }
}
