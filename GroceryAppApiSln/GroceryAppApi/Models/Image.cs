using System;
using System.Collections.Generic;

namespace GroceryAppApi.Models;

public partial class Image
{
    public int ImageId { get; set; }

    public int? ProductId { get; set; }

    public int? UserId { get; set; }

    public int? VerdorId { get; set; }

    public int? CustomerId { get; set; }

    public string ImageType { get; set; } = null!;

    public string? ImagePath { get; set; }

    public DateTime? UploadedAt { get; set; }

    public int? UploadedBy { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? UploadedByNavigation { get; set; }

    public virtual User? User { get; set; }

    public virtual Vendor? Verdor { get; set; }
}
