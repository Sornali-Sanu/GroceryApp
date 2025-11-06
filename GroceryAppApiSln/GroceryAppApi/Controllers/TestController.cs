using GroceryAppApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly GroceryDbContext _context;

        public TestController(GroceryDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetCustomer() 
        {
        var customer= _context.Customers;
        return Ok(customer);
        }

    }
}
