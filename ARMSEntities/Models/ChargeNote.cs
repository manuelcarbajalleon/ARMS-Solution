using System;
using System.Collections.Generic;

namespace ARMS_LS.Entities.Models;

public partial class ChargeNote
{
    public string TransId { get; set; } = null!;

    public string? Notes { get; set; }

    public byte[] SsmaTimeStamp { get; set; } = null!;

    public virtual Transaction Trans { get; set; } = null!;
}
