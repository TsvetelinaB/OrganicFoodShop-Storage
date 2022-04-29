using System.Linq;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using OrganicFoodShop.Models.Api;
using OrganicFoodShop.Services.Employees;
using OrganicFoodShop.Services.Products;

namespace OrganicFoodShop.Controllers.Api
{
    [ApiController]
    [Route("api/statistics")]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IProductService products;
        private readonly IEmployeeService employees;

        public StatisticsApiController(IProductService products, IEmployeeService employees)
        {
            this.products = products;
            this.employees = employees;
        }

        [HttpGet]
        [EnableCors]
        public StatisticsResponseModel Statistics()
        {
            var totalProducts = this.products.AllApiProducts().Count();
            var totalEmployees = this.employees.EmployeeCount();

            var statistics = new StatisticsResponseModel
            {
                TotalProducts = totalProducts,
                TotalEmployees = totalEmployees
            };

            return statistics;
        }
    }
}
