using GroceryAppApi.DTO;
using GroceryAppApi.Models;

namespace GroceryAppApi.Interfaces
{
    public interface IProduct
    {
        //used for async,scalability and avoid thred blocking
        Task<IEnumerable<Product>> GetAllProduct();
        Task <Product> GetProductById(int id);
        Task<Product> AddProduct(ProductViewModel product);
        Task<Product> UpdateProduct(ProductViewModel productDto);
        Task  DeleteProduct(int id);
        Task<IEnumerable<Product>> GetCategory();
    }
}
