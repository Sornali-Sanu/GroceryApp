using System;
using System.Collections.Generic;

namespace GroceryAppApi.Models;

public partial class LoginAudit
{
    public int LogId { get; set; }

    public int UserId { get; set; }

    public DateOnly? LoginTime { get; set; }

    public string? IpAddress { get; set; }

    public virtual User User { get; set; } = null!;
}
