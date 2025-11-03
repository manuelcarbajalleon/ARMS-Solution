using System;
using System.Collections.Generic;

namespace ARMS_LS.Entities.Models;

public partial class ZipCode
{
    public int? Id { get; set; }

    public double? Lat { get; set; }

    public double? Long { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? AreaCode { get; set; }

    public string? County { get; set; }

    public string? TimeZone { get; set; }

    public byte[] SsmaTimeStamp { get; set; } = null!;
}
