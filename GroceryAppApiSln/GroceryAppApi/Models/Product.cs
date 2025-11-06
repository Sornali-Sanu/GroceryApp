using System;
using System.Collections.Generic;

namespace GroceryAppApi.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int CategoryId { get; set; }

    public int VendorId { get; set; }

    public decimal CostPrice { get; set; }

    public string? Unit { get; set; }

    public decimal? SellingPrice { get; set; }

    public decimal? StockQuantity { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public bool? IsAvailable { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

    public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();

    public virtual ICollection<SalesItem> SalesItems { get; set; } = new List<SalesItem>();

    public virtual Vendor Vendor { get; set; } = null!;
}
