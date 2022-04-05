using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

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
