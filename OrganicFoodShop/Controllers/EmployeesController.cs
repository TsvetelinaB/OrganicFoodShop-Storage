using System.Linq;

using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OrganicFoodShop.Data;
using OrganicFoodShop.Data.Models;
using OrganicFoodShop.Infrastructure;
using OrganicFoodShop.Models.Employees;

namespace OrganicFoodShop.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ShopDbContext data;
        private readonly IMapper mapper;

        public EmployeesController(ShopDbContext data, IMapper mapper)
        {
            this.data = data;
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

            var userIsAlreadyEmployee = this.data
                .Employees
                .Any(e => e.UserId == userId);

            if (userIsAlreadyEmployee)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return View(employee);
}

            var employeeData = new Employee
            {
                FullName = employee.FullName,
                Username = employee.Username,
                UserId = userId
            };

            this.data.Employees.Add(employeeData);
            this.data.SaveChanges();

            return this.RedirectToAction(nameof(ProductsController.All),"Products");
        }
    }
}
