using System;
using System.Collections.Generic;

namespace ARMS_LS.Entities.Models;

public partial class Maint
{
    public DateTime? Compact { get; set; }

    public DateTime? Backup { get; set; }

    public DateTime? Restore { get; set; }
}
