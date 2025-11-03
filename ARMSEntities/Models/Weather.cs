using System;
using System.Collections.Generic;

namespace ARMS_LS.Entities.Models;

public partial class Weather
{
    public DateTime Date { get; set; }

    public string? Condition { get; set; }

    public string? Temperature { get; set; }

    public string? Precip { get; set; }

    public string? Day { get; set; }

    public string? Time { get; set; }
}
