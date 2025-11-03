using System;
using System.Collections.Generic;

namespace ARMS_LS.Entities.Models;

public partial class RunningBalance
{
    public string? CheckNo { get; set; }

    public int? CusNo { get; set; }

    public string? TransId { get; set; }

    public string? Type { get; set; }

    public DateTime? Date { get; set; }

    public string? Description { get; set; }

    public string? Debit { get; set; }

    public string? Tax { get; set; }

    public string? Credit { get; set; }

    public string? Balance { get; set; }
}
