using System;
using System.Collections.Generic;

namespace hotel_management_API.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public decimal? Salary { get; set; }

    public DateOnly? HireDate { get; set; }

    public string? Status { get; set; }
}
