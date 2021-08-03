using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using static OrganicFoodShop.Data.DataConstants;

namespace OrganicFoodShop.Data.Models
{
    public enum Category
    {
        Суперхрани = 1,
        [Display(Name = "Зърнени, семена, ядки, плодове")] ЗърнениСеменаЯдкиПлодове = 2,
        [Display(Name = "Масла, тахани")] МаслаТахани = 3,
        [Display(Name = "Кафе, чай")] КафеЧай = 4,
        [Display(Name = "Шоколади, десерти")] Шоколади,Десерти = 5,
        Напитки = 6,
        Козметика = 7
    }
}
