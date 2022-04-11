using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using OrganicFoodShop.Data.Models;
using OrganicFoodShop.Models.Products;

namespace OrganicFoodShop.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Product,ProductListingViewModel>();

            this.CreateMap<AddProductFormModel, Product>();
        }
    }
}
