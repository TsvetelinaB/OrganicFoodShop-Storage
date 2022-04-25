using AutoMapper;

using OrganicFoodShop.Data.Models;
using OrganicFoodShop.Models.Employees;
using OrganicFoodShop.Models.Products;
using OrganicFoodShop.Services.Products.Models;

namespace OrganicFoodShop.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Product,ProductListingViewModel>();

            //  this.CreateMap<AddProductFormModel, Product>();
            this.CreateMap<AddProductFormModel, AddProductServiceModel>();
            this.CreateMap<AddProductServiceModel, Product>();
            
            //is it used anywhere?
            this.CreateMap<Employee, RegisterEmployeeFormModel>();

            this.CreateMap<Category, ProductCategoryServiceModel>();

        }
    }
}
