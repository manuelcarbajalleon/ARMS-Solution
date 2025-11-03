using System;
using System.Collections.Generic;

namespace ARMS_LS.Entities.Models;

public partial class CusAging
{
    public string? _30days { get; set; }

    public string? _60days { get; set; }

    public string? _90days { get; set; }

    public string? _91days { get; set; }

    public string? Paymnt { get; set; }

    public string? Adjmnt { get; set; }
}
