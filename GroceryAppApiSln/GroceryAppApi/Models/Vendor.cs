using System;
using System.Collections.Generic;

namespace GroceryAppApi.Models;

public partial class Vendor
{
    public int VendorId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string ContactPersonFirstName { get; set; } = null!;

    public string? ContactPersonLastName { get; set; }

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public string Address { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
