using System;
using System.Collections.Generic;

namespace ARMS_LS.Entities.Models;

public partial class BillHist
{
    public int CusNo { get; set; }

    public DateTime Date { get; set; }

    public string? FileName { get; set; }
}
