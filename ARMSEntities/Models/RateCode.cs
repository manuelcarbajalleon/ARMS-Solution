using System;
using System.Collections.Generic;

namespace ARMS_LS.Entities.Models;

public partial class RateCode
{
    public string RateCode1 { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? Amount { get; set; }

    public string? Taxable { get; set; }

    public string? Edit { get; set; }

    public bool? Container { get; set; }

    public double? ContainerCus { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? LastModified { get; set; }

    public string? HourlyRate { get; set; }

    public string? DefaultRate { get; set; }

    public string? HourlyDesc { get; set; }

    public string? OneTimeRate { get; set; }

    public byte[] SsmaTimeStamp { get; set; } = null!;

    public virtual ICollection<DefaultRate> DefaultRates { get; set; } = new List<DefaultRate>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
