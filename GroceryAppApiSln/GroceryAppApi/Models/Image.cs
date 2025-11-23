using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GroceryAppApi.Models;

public partial class Image
{
    public int ImageId { get; set; }
    [JsonIgnore]
    public int? ProductId { get; set; }

    public int? UserId { get; set; }

    public int? VerdorId { get; set; }

    public int? CustomerId { get; set; }

    public string ImageType { get; set; } = null!;

    public string? ImagePath { get; set; }

    public DateTime? UploadedAt { get; set; }

    public int? UploadedBy { get; set; }
    [JsonIgnore]

    public virtual Customer? Customer { get; set; }
    [JsonIgnore]
    public virtual Product? Product { get; set; }
    [JsonIgnore]
    public virtual User? UploadedByNavigation { get; set; }
    [JsonIgnore]
    public virtual User? User { get; set; }
    [JsonIgnore]
    public virtual Vendor? Verdor { get; set; }
}
