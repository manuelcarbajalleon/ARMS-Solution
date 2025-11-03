using System;
using System.Collections.Generic;

namespace ARMS_LS.Entities.Models;

public partial class TmpExpressPayment
{
    public DateTime? Date { get; set; }

    public int CusNo { get; set; }

    public decimal Amount { get; set; }

    public string? CheckNumber { get; set; }

    public string TransId { get; set; } = null!;

    public string? Type { get; set; }

    public string? Description { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? LastModified { get; set; }
}
