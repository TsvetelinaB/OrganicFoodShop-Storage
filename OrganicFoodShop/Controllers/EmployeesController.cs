using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OrganicFoodShop.Infrastructure;
using OrganicFoodShop.Models.Employees;
using OrganicFoodShop.Services.Employees;

namespace OrganicFoodShop.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService employees;
        private readonly IMapper mapper;

        public EmployeesController(IEmployeeService employees, IMapper mapper)
        {
            this.employees = employees;
            this.mapper = mapper;
        }

        [Authorize]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Register(RegisterEmployeeFormModel employee)
        {
            var userId = this.User.GetId();

            var userIsAlreadyEmployee = this.employees.IsEmployee(userId);

            if (userIsAlreadyEmployee)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            this.employees.Register(employee.Username, employee.Position, userId);

            return this.RedirectToAction(nameof(ProductsController.All), "Products");
        }
    }
}
