using System;
using System.Collections.Generic;

namespace ARMS_LS.Entities.Models;

public partial class _120Day
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

    public DateTime? DateCreated { get; set; }

    public DateTime? LastModified { get; set; }

    public string? Notes { get; set; }
}
