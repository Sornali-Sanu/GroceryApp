using System;
using System.Collections.Generic;

namespace GroceryAppApi.Models;

public partial class PurchaseItem
{
    public int PurchaseItemId { get; set; }

    public int? PurchaseId { get; set; }

    public int? ProductId { get; set; }

    public decimal? Quantity { get; set; }

    public decimal CostPrice { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Purchase? Purchase { get; set; }
}
