using GroceryAppApi.Interfaces;
using GroceryAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryAppApi.Repositories
{
    public class EmployeeRepository : IEmployee
    {
        private readonly GroceryDbContext _db;

        public EmployeeRepository(GroceryDbContext db)
        {
            _db = db;
        }

        public Task<Employee> AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            var employees = await _db.Employees.ToListAsync();
            return employees;
        }

        public Task<Employee> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployee(Employee newEmployee)
        {
            throw new NotImplementedException();
        }
    }
}
