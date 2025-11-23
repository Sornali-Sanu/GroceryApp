using GroceryAppApi.Models;

namespace GroceryAppApi.Interfaces
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetAllEmployee();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee newEmployee);
        Task DeleteEmployee(int id);
    }
}
