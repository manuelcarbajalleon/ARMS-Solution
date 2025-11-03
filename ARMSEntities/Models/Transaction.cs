using System;
using System.Collections.Generic;

namespace ARMS_LS.Entities.Models;

public partial class Transaction
{
    public string TransId { get; set; } = null!;

    public string? InvoiceNum { get; set; }

    public string? Type { get; set; }

    public int? CusNo { get; set; }

    public DateTime? Date { get; set; }

    public string? Description { get; set; }

    public decimal? Amount { get; set; }

    public decimal? TaxAmount { get; set; }

    public string? RateCode { get; set; }

    public double? HoursWorked { get; set; }

    public string? CheckNo { get; set; }

    public string? ContainerLoc { get; set; }

    public DateTime? ContainerDue { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? LastModified { get; set; }

    public decimal? OrigAmount { get; set; }

    public string? OrigFrequency { get; set; }

    public string? PaymentType { get; set; }

    public byte[] SsmaTimeStamp { get; set; } = null!;

    public virtual ChargeNote? ChargeNote { get; set; }

    public virtual Customer? CusNoNavigation { get; set; }

    public virtual RateCode? RateCodeNavigation { get; set; }
}
