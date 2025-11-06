using System;
using System.Collections.Generic;

namespace GroceryAppApi.Models;

public partial class Purchase
{
    public int PurchaseId { get; set; }

    public int? VendorId { get; set; }

    public int? UserId { get; set; }

    public DateOnly PurchaseDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? Remarks { get; set; }

    public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();

    public virtual User? User { get; set; }

    public virtual Vendor? Vendor { get; set; }
}
