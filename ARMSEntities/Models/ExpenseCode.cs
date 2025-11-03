using System;
using System.Collections.Generic;

namespace ARMS_LS.Entities.Models;

public partial class ExpenseCode
{
    public string ExpenseCode1 { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? LastModified { get; set; }

    public int? RunningTotal { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}
