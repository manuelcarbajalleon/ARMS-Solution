using System;
using System.Collections.Generic;

namespace ARMS_LS.Entities.Models;

public partial class DefaultRate
{
    public int AutoId { get; set; }

    public int? CusNo { get; set; }

    public string? RateId { get; set; }

    public decimal? Amount { get; set; }

    public string? Description { get; set; }

    public bool? DefRate { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? LastModified { get; set; }

    public byte[] SsmaTimeStamp { get; set; } = null!;

    public virtual RateCode? Rate { get; set; }
}
