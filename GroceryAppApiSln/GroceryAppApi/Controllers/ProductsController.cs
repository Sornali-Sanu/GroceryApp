using GroceryAppApi.DTO;
using GroceryAppApi.Models;
using GroceryAppApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroceryAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        ProductRepository productRepo= new ProductRepository();
        [HttpGet]
        public async Task< IActionResult> GetProductList()
        {
            //var productList =await productRepo.GetAllProduct();
            //return Ok(productList);
            var productList = await productRepo.GetAllProduct();

            foreach (var p in productList)
            {
                Console.WriteLine($"Product: {p.ProductId}, Images: {p.Images.Count}");
            }

            return Ok(productList);
        }
        [HttpGet("{id}")]
        public async Task <IActionResult> GetProductBySelectedId(int id) 
        {
            var chooseProduct = await productRepo.GetProductById(id);
            if (chooseProduct == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return Ok(chooseProduct);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewProduct([FromBody] ProductViewModel product)
        {
            if (product == null)
            { return BadRequest("Product data is missing."); }


            var addedProduct = await productRepo.AddProduct(product);
            return CreatedAtAction(nameof(GetProductBySelectedId), new { id = addedProduct.ProductId }, addedProduct);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExsitingProduct(int id, [FromBody] ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Validation failed");
            }
            if (id != product.ProductId)
            {
                return BadRequest("Product Id Mis match");
            }

           
             var updateProduct=await productRepo.UpdateProduct(product);
            if (updateProduct == null)
            {
                return BadRequest("Update Product Not Found");
            }
            return Ok(updateProduct);
        
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid product ID.");
            await productRepo.DeleteProduct(id);

          return Ok($"Product has been deleted successfully.");

        }

    }
}
