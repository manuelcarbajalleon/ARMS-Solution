using System;
using System.Collections.Generic;

namespace ARMS_LS.Entities.Models;

public partial class WeatherStation
{
    public int Id { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }
}
