using System;
using System.Collections.Generic;

namespace GroceryAppApi.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public string UserRole { get; set; } = null!;

    public string UserStatus { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public string Password { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Image> ImageUploadedByNavigations { get; set; } = new List<Image>();

    public virtual ICollection<Image> ImageUsers { get; set; } = new List<Image>();

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

    public virtual ICollection<LoginAudit> LoginAudits { get; set; } = new List<LoginAudit>();

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
