namespace OrganicFoodShop.Services.Employees
{
    public interface IEmployeeService
    {
        int EmployeeId(string userId);

        bool IsEmployee(string userId);

        void Register(string username, string position, string userId);

        int EmployeeCount();
    }
}
