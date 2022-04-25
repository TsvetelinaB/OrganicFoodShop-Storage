using System.Linq;

using AutoMapper;

using OrganicFoodShop.Data;
using OrganicFoodShop.Data.Models;
using OrganicFoodShop.Models.Employees;

namespace OrganicFoodShop.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ShopDbContext data;
        private readonly IMapper mapper;

        public EmployeeService(ShopDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public int EmployeeId(string userId)
        {
            return this.data
                        .Employees
                        .Where(e => e.UserId == userId)
                        .Select(e => e.Id)
                        .FirstOrDefault();
        }

        public bool IsEmployee(string userId)
        {
            return this.data
                        .Employees
                        .Any(e => e.UserId == userId);
        }

        public void Register (string fullName, string username, string userId)
        {
            var employeeData = new Employee
            {
                FullName = fullName,
                Username = username,
                UserId = userId
            };

            this.data.Add(employeeData);
            this.data.SaveChanges();
        }
    }
}
