using System;
using System.Collections.Generic;

namespace GroceryAppApi.Models;

public partial class SalesItem
{
    public int SalesItemId { get; set; }

    public int? SaleId { get; set; }

    public int? ProductId { get; set; }

    public decimal Quantity { get; set; }

    public decimal SellingPrice { get; set; }

    public decimal? Discount { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Sale? Sale { get; set; }
}
