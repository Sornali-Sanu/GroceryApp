using System;
using System.Collections.Generic;

namespace GroceryAppApi.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public int? UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string Position { get; set; } = null!;

    public DateTime? HireDate { get; set; }

    public decimal? Salary { get; set; }

    public string? EmployeeStatus { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User? User { get; set; }
}
