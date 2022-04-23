using System.Linq;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using OrganicFoodShop.Data;
using OrganicFoodShop.Models.Api;

namespace OrganicFoodShop.Controllers.Api
{
    [ApiController]
    [Route("api/statistics")]
    public class StatisticsApiController : ControllerBase
    {
        private readonly ShopDbContext data;

        public StatisticsApiController(ShopDbContext data)
        {
            this.data = data;
        }

        [HttpGet]
        [EnableCors]
        public StatisticsResponseModel Statistics()
        {
            var totalProducts = this.data.Products.Count();
            var totalEmployees = this.data.Employees.Count();

            var statistics = new StatisticsResponseModel
            {
                TotalProducts = totalProducts,
                TotalEmployees = totalEmployees
            };

            return statistics;
        }
    }
}
