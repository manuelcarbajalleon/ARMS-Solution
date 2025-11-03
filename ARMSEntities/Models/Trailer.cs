using System;
using System.Collections.Generic;

namespace ARMS_LS.Entities.Models;

public partial class Trailer
{
    public string? TrailerMessage { get; set; }

    public byte[] SsmaTimeStamp { get; set; } = null!;
}
