using GroceryAppApi.Interfaces;
using GroceryAppApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployee employeeRepo;

        public EmployeesController(IEmployee employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeList()
        {
            var employee=await employeeRepo.GetAllEmployee();
            return Ok(employee);
        }
    }
}
