using System.Linq;

using OrganicFoodShop.Data;
using OrganicFoodShop.Data.Models;

namespace OrganicFoodShop.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ShopDbContext data;

        public EmployeeService(ShopDbContext data)
        {
            this.data = data;
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
