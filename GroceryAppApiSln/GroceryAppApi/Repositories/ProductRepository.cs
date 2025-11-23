using GroceryAppApi.DTO;
using GroceryAppApi.Interfaces;
using GroceryAppApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace GroceryAppApi.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly GroceryDbContext _context = new GroceryDbContext();

        public async Task<Product> AddProduct(ProductViewModel productDto)
        {
           if(string.IsNullOrWhiteSpace(productDto.ProductName))
           throw new ArgumentException("Product name cannot be empty.");

            var product = new Product
            {
                ProductName = productDto.ProductName,
                CategoryId = productDto.CategoryId,
                VendorId = productDto.VendorId,
                CostPrice = productDto.CostPrice,
                Unit = productDto.Unit ?? "Kg",
                SellingPrice = productDto.SellingPrice,
                StockQuantity = productDto.StockQuantity,
                ExpiryDate=productDto.ExpiryDate,
                IsAvailable = productDto.IsAvailable ?? true
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task DeleteProduct(int id)
        {
           var product= await _context.Products.FirstOrDefaultAsync(x=>x.ProductId == id);
           if(product==null)
           return;
           _context.Products.Remove(product);
           await _context.SaveChangesAsync();
           return;
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
           var products =await _context.Products.Include(x=>x.Images).
          ToListAsync();
           return products;
        }

        public Task<IEnumerable<Product>> GetCategory()
        {
            throw new NotImplementedException();
        }

        public async Task<Product?> GetProductById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x=>x.ProductId==id);
            if (product == null)
            {
                return null;
            }
                return product;
        }

        public async Task<Product?> UpdateProduct(ProductViewModel productDto)
        {
            var exsitProduct = await _context.Products.FirstOrDefaultAsync(p=>p.ProductId==productDto.ProductId);
            if (exsitProduct == null) {
                return null;
            }
            exsitProduct.ProductName = productDto.ProductName;
            exsitProduct.CategoryId = productDto.CategoryId;
            exsitProduct.VendorId = productDto.VendorId;
            exsitProduct.CostPrice = productDto.CostPrice;
            exsitProduct.Unit = productDto.Unit ?? "Kg";
            exsitProduct.SellingPrice = productDto.SellingPrice;
            exsitProduct.StockQuantity = productDto.StockQuantity;
            exsitProduct.ExpiryDate = productDto.ExpiryDate;
            exsitProduct.IsAvailable = productDto.IsAvailable ?? true;

            await _context.SaveChangesAsync();
            return exsitProduct;




        }
    }
}
