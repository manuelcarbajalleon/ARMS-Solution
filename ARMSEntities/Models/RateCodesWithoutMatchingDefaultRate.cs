using System;
using System.Collections.Generic;

namespace ARMS_LS.Entities.Models;

public partial class RateCodesWithoutMatchingDefaultRate
{
    public string RateCode { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? Amount { get; set; }
}
