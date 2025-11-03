using System;
using System.Collections.Generic;

namespace ARMS_LS.Entities.Models;

public partial class Customer
{
    public int CusNo { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? ServlocSt { get; set; }

    public string? ServlocNm { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? Phone { get; set; }

    public string? Ext { get; set; }

    public string? AltPhone { get; set; }

    public string? AltExt { get; set; }

    public string? Contact { get; set; }

    public string? BillToName { get; set; }

    public string? BillToAddress { get; set; }

    public string? BillToCity { get; set; }

    public string? BillToState { get; set; }

    public string? BillToZip { get; set; }

    public string? BillToPhone { get; set; }

    public string? BillToExt { get; set; }

    public string? BillToAltPhone { get; set; }

    public string? BillToAltExt { get; set; }

    public string? BillToContact { get; set; }

    public string? Email { get; set; }

    public string? RateCode { get; set; }

    public string? TypeCode { get; set; }

    public string? SubType { get; set; }

    public double? RouteMin { get; set; }

    public int? RouteStop { get; set; }

    public string? RouteCode { get; set; }

    public decimal? Balance { get; set; }

    public string? Notes { get; set; }

    public string? Tax { get; set; }

    public string? WhatToDo { get; set; }

    public string? Frequency { get; set; }

    public DateTime? ServStartDate { get; set; }

    public DateTime? ServEndDate { get; set; }

    public DateTime? ServResumeDate { get; set; }

    public decimal? BillCharges { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? LastModified { get; set; }

    public string? BillFreq { get; set; }

    public string? BillType { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? ResumeDate { get; set; }

    public DateTime? SuspendDate { get; set; }

    public DateTime? DiaryDate { get; set; }

    public string? BankAcctNumber { get; set; }

    public string? DiaryNotes { get; set; }

    public string? HistoryNotes { get; set; }

    public string? AccountingNotes { get; set; }

    public string? ContractNotes { get; set; }

    public double? CusTaxAmount { get; set; }

    public byte[] SsmaTimeStamp { get; set; } = null!;

    public virtual RouteCode? RouteCodeNavigation { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual TypeCode? TypeCodeNavigation { get; set; }
}
