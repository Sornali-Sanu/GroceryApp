using System;
using System.Collections.Generic;

namespace GroceryAppApi.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public int? CustomerId { get; set; }

    public int? UserId { get; set; }

    public DateOnly? SaleDate { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal PaymentAmount { get; set; }

    public string? PaymentMethod { get; set; }

    public string? Remarks { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<SalesItem> SalesItems { get; set; } = new List<SalesItem>();

    public virtual User? User { get; set; }
}
