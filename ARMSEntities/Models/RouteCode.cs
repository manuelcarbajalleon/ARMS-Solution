using System;
using System.Collections.Generic;

namespace ARMS_LS.Entities.Models;

public partial class RouteCode
{
    public string RouteCode1 { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? LastModified { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
