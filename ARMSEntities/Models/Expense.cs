using System;
using System.Collections.Generic;

namespace ARMS_LS.Entities.Models;

public partial class Expense
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public string? ExpenseCode { get; set; }

    public string? ExpMajor { get; set; }

    public decimal? Amount { get; set; }

    public string? Description { get; set; }

    public string? Ck { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? LastModified { get; set; }

    public virtual ExpenseCode? ExpenseCodeNavigation { get; set; }
}
