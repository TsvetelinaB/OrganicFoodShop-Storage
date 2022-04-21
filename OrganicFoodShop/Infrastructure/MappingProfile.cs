
using AutoMapper;

using OrganicFoodShop.Data.Models;
using OrganicFoodShop.Models.Employees;
using OrganicFoodShop.Models.Products;

namespace OrganicFoodShop.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Product,ProductListingViewModel>();

            this.CreateMap<AddProductFormModel, Product>();

            this.CreateMap<Employee, RegisterEmployeeFormModel>();

        }
    }
}
