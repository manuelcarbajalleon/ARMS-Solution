using System;
using System.Collections.Generic;

namespace ARMS_LS.Entities.Models;

public partial class Company
{
    public string? CompName { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? Telephone { get; set; }

    public string? Fax { get; set; }

    public string? CompanyEmail { get; set; }

    public string? Background { get; set; }

    public string? Foreground { get; set; }

    public bool? RecurseData { get; set; }

    public string? Nntu { get; set; }

    public bool? AutoGenerateCusNo { get; set; }

    public string? BillFormat { get; set; }

    public bool? PrintRemittance { get; set; }

    public string? Completed { get; set; }

    public bool? ShowUpdt { get; set; }

    public bool? ChargeTax { get; set; }

    public string? SalesTax { get; set; }

    public bool? CaptureBillHistory { get; set; }

    public bool? TransDate { get; set; }

    public short? Type { get; set; }

    public string? ExtraNumLabel1 { get; set; }

    public string? ExtraNum1 { get; set; }

    public string? ExtraNumLabel2 { get; set; }

    public string? ExtraNum2 { get; set; }

    public string? Space { get; set; }

    public string? BillColor { get; set; }

    public bool? SaveSnap2 { get; set; }

    public string? AgingBy { get; set; }

    public string? Version { get; set; }

    public string? BalFwrd { get; set; }

    public string? SbCod { get; set; }

    public string? NextInvNum { get; set; }

    public string? Serial { get; set; }

    public string? WeatherWebSite { get; set; }

    public string? WeatherStation { get; set; }

    public string? PrintDash { get; set; }

    public string? PrefillAmount { get; set; }

    public string? ShowTips { get; set; }

    public string? DefRates { get; set; }

    public string? EnableWebAccess { get; set; }

    public string? ShowToolbarTip { get; set; }

    public string? CompanyLogoAlign { get; set; }

    public string? BackupPath { get; set; }

    public int? BackupReminder { get; set; }

    public DateTime? LastReminder { get; set; }

    public string? SortOrder { get; set; }

    public string? ListValue { get; set; }

    public string? PrintBillAging { get; set; }

    public DateTime? LastMac { get; set; }

    public DateTime? LastBac { get; set; }

    public DateTime? LastQac { get; set; }

    public DateTime? LastSac { get; set; }

    public DateTime? LastAac { get; set; }

    public string? CompanyLogo { get; set; }

    public string? Watermark { get; set; }

    public string? DefPrinter { get; set; }

    public byte[] SsmaTimeStamp { get; set; } = null!;
}
