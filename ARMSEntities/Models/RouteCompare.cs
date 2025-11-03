using System;
using System.Collections.Generic;

namespace ARMS_LS.Entities.Models;

public partial class RouteCompare
{
    public int Autonumber { get; set; }

    public short? CusNo { get; set; }

    public string? RouteCode { get; set; }

    public int? RouteMin { get; set; }

    public int? RouteStop { get; set; }
}
