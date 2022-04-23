using System.Linq;

using OrganicFoodShop.Data;

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
    }
}
