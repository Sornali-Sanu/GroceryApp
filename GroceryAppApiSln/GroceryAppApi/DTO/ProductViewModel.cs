using GroceryAppApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroceryAppApi.DTO
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; } = null!;

        public int CategoryId { get; set; }

        public int VendorId { get; set; }
        [Required]
        public decimal CostPrice { get; set; }


        public string? Unit { get; set; } = "kg";
        [Required]
        public decimal SellingPrice { get; set; }

        public decimal? StockQuantity { get; set; }
        [Required]
        public DateOnly ExpiryDate { get; set; }

        public bool? IsAvailable { get; set; }
       
        public virtual Category? Category { get; set; } = null!;
     
        public virtual ICollection<Image>? Images { get; set; } = new List<Image>();
      
        public virtual ICollection<InventoryTransaction> ? InventoryTransactions { get; set; } = new List<InventoryTransaction>();
    
        public virtual ICollection<PurchaseItem>? PurchaseItems { get; set; } = new List<PurchaseItem>();
     
        public virtual ICollection<SalesItem>? SalesItems { get; set; } = new List<SalesItem>();
       
        public virtual Vendor? Vendor { get; set; } = null!;
    }
}
