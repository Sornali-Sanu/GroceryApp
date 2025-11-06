using System;
using System.Collections.Generic;

namespace GroceryAppApi.Models;

public partial class InventoryTransaction
{
    public int InventoryTransactionId { get; set; }

    public int? ProductId { get; set; }

    public string? ChangeType { get; set; }

    public int? UserId { get; set; }

    public decimal QuantityChange { get; set; }

    public DateOnly? TransactionDate { get; set; }

    public int? ReferenceId { get; set; }

    public string? Remarks { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
