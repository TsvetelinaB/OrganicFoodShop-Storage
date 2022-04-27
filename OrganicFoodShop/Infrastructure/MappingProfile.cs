using AutoMapper;

using OrganicFoodShop.Data.Models;
using OrganicFoodShop.Models.Products;
using OrganicFoodShop.Services.Products.Models;

namespace OrganicFoodShop.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Product, ProductListingViewModel>();

            this.CreateMap<AddProductFormModel, AddProductServiceModel>();

            this.CreateMap<Category, ProductCategoryServiceModel>();

            this.CreateMap<AddProductServiceModel, Product>();

            this.CreateMap<Product, ProductDetailsViewModel>();

            // are they used anywhere?
            // this.CreateMap<AddProductFormModel, Product>();
            // this.CreateMap<Employee, RegisterEmployeeFormModel>();




        }
    }
}
