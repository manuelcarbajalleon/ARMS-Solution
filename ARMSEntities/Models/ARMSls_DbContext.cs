using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ARMS_LS.Entities.Models;

public partial class ARMSls_DbContext : DbContext
{
    public ARMSls_DbContext()
    {
    }

    public ARMSls_DbContext(DbContextOptions<ARMSls_DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BillHist> BillHists { get; set; }

    public virtual DbSet<ChargeNote> ChargeNotes { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CusAging> CusAgings { get; set; }

    public virtual DbSet<CusNoGap> CusNoGaps { get; set; }

    public virtual DbSet<CusNoLast> CusNoLasts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DefaultRate> DefaultRates { get; set; }

    public virtual DbSet<DefaultRatesCopy> DefaultRatesCopies { get; set; }

    public virtual DbSet<Description> Descriptions { get; set; }

    public virtual DbSet<EvalCustomer> EvalCustomers { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<ExpenseCode> ExpenseCodes { get; set; }

    public virtual DbSet<Favory> Favories { get; set; }

    public virtual DbSet<Font> Fonts { get; set; }

    public virtual DbSet<Maint> Maints { get; set; }

    public virtual DbSet<NextCustNum> NextCustNums { get; set; }

    public virtual DbSet<RateCode> RateCodes { get; set; }

    public virtual DbSet<RateCodesWithoutMatchingDefaultRate> RateCodesWithoutMatchingDefaultRates { get; set; }

    public virtual DbSet<RouteCode> RouteCodes { get; set; }

    public virtual DbSet<RouteCompare> RouteCompares { get; set; }

    public virtual DbSet<RunningBalance> RunningBalances { get; set; }

    public virtual DbSet<SelectFromRateCodesOrderByRateCode> SelectFromRateCodesOrderByRateCodes { get; set; }

    public virtual DbSet<SelectFromTypeCodesOrderByTypeCode> SelectFromTypeCodesOrderByTypeCodes { get; set; }

    public virtual DbSet<SnapshotCu> SnapshotCus { get; set; }

    public virtual DbSet<SumtmpPayment> SumtmpPayments { get; set; }

    public virtual DbSet<Tip> Tips { get; set; }

    public virtual DbSet<TmpExpressPayment> TmpExpressPayments { get; set; }

    public virtual DbSet<TotalCu> TotalCus { get; set; }

    public virtual DbSet<TotalTip> TotalTips { get; set; }

    public virtual DbSet<Trailer> Trailers { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TypeCode> TypeCodes { get; set; }

    public virtual DbSet<Weather> Weathers { get; set; }

    public virtual DbSet<WeatherStation> WeatherStations { get; set; }

    public virtual DbSet<WeatherStations1> WeatherStations1s { get; set; }

    public virtual DbSet<ZipCode> ZipCodes { get; set; }

    public virtual DbSet<_120Day> _120Days { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\data\\ARMSls.mdf;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BillHist>(entity =>
        {
            entity.HasKey(e => new { e.CusNo, e.Date }).HasName("BillHist$PrimaryKey");

            entity.ToTable("BillHist");

            entity.Property(e => e.Date).HasPrecision(0);
            entity.Property(e => e.FileName).HasMaxLength(50);
        });

        modelBuilder.Entity<ChargeNote>(entity =>
        {
            entity.HasKey(e => e.TransId).HasName("ChargeNotes$PrimaryKey");

            entity.HasIndex(e => e.TransId, "ChargeNotes$TransactionID");

            entity.HasIndex(e => e.TransId, "ChargeNotes${7F91432F-2D12-4A93-9E66-60B131F7A8AA}").IsUnique();

            entity.Property(e => e.TransId)
                .HasMaxLength(255)
                .HasColumnName("TransID");
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");

            entity.HasOne(d => d.Trans).WithOne(p => p.ChargeNote)
                .HasForeignKey<ChargeNote>(d => d.TransId)
                .HasConstraintName("ChargeNotes$[C:\\armsls\\data\\armsdata.mde].{7F91432F-2D12-4A93-9E66-60B131F7A8AA}");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Company");

            entity.HasIndex(e => e.NextInvNum, "Company$NextInvNum");

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.AgingBy)
                .HasMaxLength(6)
                .HasDefaultValue("Months");
            entity.Property(e => e.AutoGenerateCusNo).HasDefaultValue(false);
            entity.Property(e => e.Background)
                .HasMaxLength(20)
                .HasDefaultValue("6723891");
            entity.Property(e => e.BackupPath)
                .HasMaxLength(255)
                .HasDefaultValue("C:\\armsls\\data\\backup\\");
            entity.Property(e => e.BackupReminder).HasDefaultValue(-1);
            entity.Property(e => e.BalFwrd)
                .HasMaxLength(3)
                .HasDefaultValue("No");
            entity.Property(e => e.BillColor).HasMaxLength(3);
            entity.Property(e => e.BillFormat).HasMaxLength(1);
            entity.Property(e => e.CaptureBillHistory).HasDefaultValue(false);
            entity.Property(e => e.ChargeTax).HasDefaultValue(false);
            entity.Property(e => e.City).HasMaxLength(25);
            entity.Property(e => e.CompName).HasMaxLength(40);
            entity.Property(e => e.CompanyEmail).HasMaxLength(255);
            entity.Property(e => e.CompanyLogo).HasMaxLength(255);
            entity.Property(e => e.CompanyLogoAlign)
                .HasMaxLength(1)
                .HasDefaultValue("2");
            entity.Property(e => e.Completed)
                .HasMaxLength(1)
                .HasDefaultValue("N");
            entity.Property(e => e.DefPrinter).HasMaxLength(255);
            entity.Property(e => e.DefRates)
                .HasMaxLength(9)
                .HasDefaultValue("One");
            entity.Property(e => e.EnableWebAccess).HasMaxLength(50);
            entity.Property(e => e.ExtraNum1).HasMaxLength(14);
            entity.Property(e => e.ExtraNum2).HasMaxLength(14);
            entity.Property(e => e.ExtraNumLabel1).HasMaxLength(50);
            entity.Property(e => e.ExtraNumLabel2).HasMaxLength(50);
            entity.Property(e => e.Fax).HasMaxLength(14);
            entity.Property(e => e.Foreground)
                .HasMaxLength(20)
                .HasDefaultValue("16777215");
            entity.Property(e => e.LastAac)
                .HasPrecision(0)
                .HasColumnName("LastAAC");
            entity.Property(e => e.LastBac)
                .HasPrecision(0)
                .HasColumnName("LastBAC");
            entity.Property(e => e.LastMac)
                .HasPrecision(0)
                .HasColumnName("LastMAC");
            entity.Property(e => e.LastQac)
                .HasPrecision(0)
                .HasColumnName("LastQAC");
            entity.Property(e => e.LastReminder)
                .HasPrecision(0)
                .HasDefaultValueSql("(format(getdate(),'mm/dd/yy'))");
            entity.Property(e => e.LastSac)
                .HasPrecision(0)
                .HasColumnName("LastSAC");
            entity.Property(e => e.ListValue).HasMaxLength(10);
            entity.Property(e => e.NextInvNum).HasMaxLength(20);
            entity.Property(e => e.Nntu)
                .HasMaxLength(9)
                .HasColumnName("NNTU");
            entity.Property(e => e.PrefillAmount)
                .HasMaxLength(3)
                .HasDefaultValue("Yes");
            entity.Property(e => e.PrintBillAging).HasMaxLength(10);
            entity.Property(e => e.PrintDash)
                .HasMaxLength(3)
                .HasDefaultValue("Yes");
            entity.Property(e => e.PrintRemittance).HasDefaultValue(false);
            entity.Property(e => e.RecurseData).HasDefaultValue(false);
            entity.Property(e => e.SalesTax).HasMaxLength(6);
            entity.Property(e => e.SaveSnap2).HasDefaultValue(false);
            entity.Property(e => e.SbCod).HasMaxLength(50);
            entity.Property(e => e.Serial).HasMaxLength(50);
            entity.Property(e => e.ShowTips)
                .HasMaxLength(3)
                .HasDefaultValue("Yes");
            entity.Property(e => e.ShowToolbarTip)
                .HasMaxLength(3)
                .HasDefaultValue("Yes");
            entity.Property(e => e.ShowUpdt).HasDefaultValue(false);
            entity.Property(e => e.SortOrder).HasMaxLength(10);
            entity.Property(e => e.Space).HasMaxLength(50);
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
            entity.Property(e => e.State).HasMaxLength(2);
            entity.Property(e => e.Telephone).HasMaxLength(14);
            entity.Property(e => e.TransDate).HasDefaultValue(false);
            entity.Property(e => e.Type).HasDefaultValue((short)1);
            entity.Property(e => e.Version).HasMaxLength(10);
            entity.Property(e => e.Watermark).HasMaxLength(255);
            entity.Property(e => e.WeatherStation)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.WeatherWebSite).HasMaxLength(100);
            entity.Property(e => e.Zip).HasMaxLength(11);
        });

        modelBuilder.Entity<CusAging>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CusAging");

            entity.Property(e => e.Adjmnt).HasMaxLength(255);
            entity.Property(e => e.Paymnt).HasMaxLength(255);
            entity.Property(e => e._30days)
                .HasMaxLength(255)
                .HasColumnName("30Days");
            entity.Property(e => e._60days)
                .HasMaxLength(255)
                .HasColumnName("60Days");
            entity.Property(e => e._90days)
                .HasMaxLength(255)
                .HasColumnName("90Days");
            entity.Property(e => e._91days)
                .HasMaxLength(255)
                .HasColumnName("91Days");
        });

        modelBuilder.Entity<CusNoGap>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CusNo Gap");
        });

        modelBuilder.Entity<CusNoLast>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CusNo Last");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CusNo).HasName("Customers$PrimaryKey");

            entity.HasIndex(e => e.BillToAltPhone, "Customers$AltPhone");

            entity.HasIndex(e => e.AltPhone, "Customers$CusAltNum");

            entity.HasIndex(e => e.Phone, "Customers$CusNum");

            entity.HasIndex(e => e.BillToPhone, "Customers$Phone");

            entity.HasIndex(e => e.RateCode, "Customers$RateCode");

            entity.HasIndex(e => e.RouteCode, "Customers$RouteCode");

            entity.HasIndex(e => e.TypeCode, "Customers$TypeCode");

            entity.HasIndex(e => e.RouteStop, "Customers$cusroutestop");

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.AltExt)
                .HasMaxLength(20)
                .HasColumnName("AltEXT");
            entity.Property(e => e.AltPhone).HasMaxLength(15);
            entity.Property(e => e.Balance)
                .HasDefaultValueSql("('$0.00')")
                .HasColumnType("money");
            entity.Property(e => e.BankAcctNumber).HasMaxLength(20);
            entity.Property(e => e.BillCharges)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.BillFreq).HasMaxLength(1);
            entity.Property(e => e.BillToAddress).HasMaxLength(50);
            entity.Property(e => e.BillToAltExt)
                .HasMaxLength(20)
                .HasColumnName("BillToAltEXT");
            entity.Property(e => e.BillToAltPhone).HasMaxLength(15);
            entity.Property(e => e.BillToCity).HasMaxLength(25);
            entity.Property(e => e.BillToContact).HasMaxLength(75);
            entity.Property(e => e.BillToExt)
                .HasMaxLength(20)
                .HasColumnName("BillToEXT");
            entity.Property(e => e.BillToName).HasMaxLength(75);
            entity.Property(e => e.BillToPhone).HasMaxLength(15);
            entity.Property(e => e.BillToState).HasMaxLength(2);
            entity.Property(e => e.BillToZip).HasMaxLength(11);
            entity.Property(e => e.BillType).HasMaxLength(5);
            entity.Property(e => e.City).HasMaxLength(25);
            entity.Property(e => e.Contact).HasMaxLength(75);
            entity.Property(e => e.DateCreated)
                .HasPrecision(0)
                .HasDefaultValueSql("(format(getdate(),'mm/dd/yy'))");
            entity.Property(e => e.DiaryDate).HasPrecision(0);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.EndDate).HasPrecision(0);
            entity.Property(e => e.Ext)
                .HasMaxLength(20)
                .HasColumnName("EXT");
            entity.Property(e => e.Frequency).HasMaxLength(50);
            entity.Property(e => e.LastModified).HasPrecision(0);
            entity.Property(e => e.Name).HasMaxLength(75);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.RateCode).HasMaxLength(5);
            entity.Property(e => e.ResumeDate).HasPrecision(0);
            entity.Property(e => e.RouteCode).HasMaxLength(3);
            entity.Property(e => e.RouteStop).HasDefaultValue(0);
            entity.Property(e => e.ServEndDate).HasPrecision(0);
            entity.Property(e => e.ServResumeDate).HasPrecision(0);
            entity.Property(e => e.ServStartDate).HasPrecision(0);
            entity.Property(e => e.ServlocNm).HasMaxLength(10);
            entity.Property(e => e.ServlocSt).HasMaxLength(100);
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
            entity.Property(e => e.StartDate).HasPrecision(0);
            entity.Property(e => e.State).HasMaxLength(2);
            entity.Property(e => e.SubType).HasMaxLength(5);
            entity.Property(e => e.SuspendDate).HasPrecision(0);
            entity.Property(e => e.Tax)
                .HasMaxLength(1)
                .HasDefaultValue("N");
            entity.Property(e => e.TypeCode).HasMaxLength(1);
            entity.Property(e => e.Zip).HasMaxLength(11);

            entity.HasOne(d => d.RouteCodeNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.RouteCode)
                .HasConstraintName("Customers$[C:\\armsls\\data\\armsdata.mde].{E1B3BBE8-23F5-4BF9-B704-58782C9260BC}");

            entity.HasOne(d => d.TypeCodeNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.TypeCode)
                .HasConstraintName("Customers$[C:\\armsls\\data\\armsdata.mde].{675EAAD1-82E7-4539-B66E-7226B1B12FDF}");
        });

        modelBuilder.Entity<DefaultRate>(entity =>
        {
            entity.HasKey(e => e.AutoId).HasName("DefaultRates$PrimaryKey");

            entity.HasIndex(e => e.AutoId, "DefaultRates$AutoID");

            entity.HasIndex(e => e.CusNo, "DefaultRates$DefaultRatesCusNo");

            entity.HasIndex(e => e.RateId, "DefaultRates$RateID");

            entity.Property(e => e.AutoId).HasColumnName("AutoID");
            entity.Property(e => e.Amount)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.CusNo).HasDefaultValue(0);
            entity.Property(e => e.DateCreated)
                .HasPrecision(0)
                .HasDefaultValueSql("(format(getdate(),'mm/dd/yy'))");
            entity.Property(e => e.DefRate).HasDefaultValue(false);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.LastModified).HasPrecision(0);
            entity.Property(e => e.RateId)
                .HasMaxLength(3)
                .HasColumnName("RateID");
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");

            entity.HasOne(d => d.Rate).WithMany(p => p.DefaultRates)
                .HasForeignKey(d => d.RateId)
                .HasConstraintName("DefaultRates$[C:\\armsls\\data\\armsdata.mde].{3E4F8610-595B-486A-9D4F-DD8A8FBF8A9B}");
        });

        modelBuilder.Entity<DefaultRatesCopy>(entity =>
        {
            entity.HasKey(e => e.AutoId).HasName("DefaultRatesCopy$PrimaryKey");

            entity.ToTable("DefaultRatesCopy");

            entity.HasIndex(e => e.AutoId, "DefaultRatesCopy$AutoID");

            entity.HasIndex(e => e.CusNo, "DefaultRatesCopy$DefaultRatesCusNo");

            entity.HasIndex(e => e.RateId, "DefaultRatesCopy$RateID");

            entity.Property(e => e.AutoId).HasColumnName("AutoID");
            entity.Property(e => e.Amount)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.CusNo).HasDefaultValue(0);
            entity.Property(e => e.DateCreated)
                .HasPrecision(0)
                .HasDefaultValueSql("(format(getdate(),'mm/dd/yy'))");
            entity.Property(e => e.DefRate).HasDefaultValue(false);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.LastModified).HasPrecision(0);
            entity.Property(e => e.RateId)
                .HasMaxLength(3)
                .HasColumnName("RateID");
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
        });

        modelBuilder.Entity<Description>(entity =>
        {
            entity.HasKey(e => e.AutoId).HasName("Descriptions$PrimaryKey");

            entity.HasIndex(e => e.AutoId, "Descriptions$AutoID");

            entity.Property(e => e.AutoId).HasColumnName("AutoID");
            entity.Property(e => e.Description1)
                .HasMaxLength(255)
                .HasColumnName("Description");
        });

        modelBuilder.Entity<EvalCustomer>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("EvalCustomers");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Expenses$PrimaryKey");

            entity.HasIndex(e => e.Description, "Expenses$Description");

            entity.HasIndex(e => e.Date, "Expenses$ExpDate");

            entity.HasIndex(e => e.ExpenseCode, "Expenses$ExpenseCode");

            entity.HasIndex(e => e.Id, "Expenses$ID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.Ck)
                .HasMaxLength(10)
                .HasColumnName("CK#");
            entity.Property(e => e.Date)
                .HasPrecision(0)
                .HasDefaultValueSql("(format(getdate(),'Short Date'))");
            entity.Property(e => e.DateCreated)
                .HasPrecision(0)
                .HasDefaultValueSql("(format(getdate(),'mm/dd/yy'))");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ExpMajor).HasMaxLength(50);
            entity.Property(e => e.ExpenseCode).HasMaxLength(6);
            entity.Property(e => e.LastModified).HasPrecision(0);

            entity.HasOne(d => d.ExpenseCodeNavigation).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.ExpenseCode)
                .HasConstraintName("Expenses$[C:\\armsls\\data\\armsdata.mde].{D62DE8A9-80E6-4988-9972-C329FD6CA11A}");
        });

        modelBuilder.Entity<ExpenseCode>(entity =>
        {
            entity.HasKey(e => e.ExpenseCode1).HasName("ExpenseCodes$PrimaryKey");

            entity.HasIndex(e => e.ExpenseCode1, "ExpenseCodes$ExpenseCode").IsUnique();

            entity.Property(e => e.ExpenseCode1)
                .HasMaxLength(6)
                .HasColumnName("ExpenseCode");
            entity.Property(e => e.DateCreated)
                .HasPrecision(0)
                .HasDefaultValueSql("(format(getdate(),'mm/dd/yy'))");
            entity.Property(e => e.Description).HasMaxLength(40);
            entity.Property(e => e.LastModified).HasPrecision(0);
            entity.Property(e => e.RunningTotal)
                .HasDefaultValueSql("('$0.00')")
                .HasColumnName("Running total");
        });

        modelBuilder.Entity<Favory>(entity =>
        {
            entity.HasKey(e => e.AutoId).HasName("Favories$PrimaryKey");

            entity.HasIndex(e => e.AutoId, "Favories$AutoID");

            entity.Property(e => e.AutoId).HasColumnName("AutoID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<Font>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Maint>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Maint");

            entity.Property(e => e.Backup).HasPrecision(0);
            entity.Property(e => e.Compact).HasPrecision(0);
            entity.Property(e => e.Restore).HasPrecision(0);
        });

        modelBuilder.Entity<NextCustNum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NextCustNum");

            entity.Property(e => e.Nntu)
                .HasMaxLength(9)
                .HasColumnName("NNTU");
        });

        modelBuilder.Entity<RateCode>(entity =>
        {
            entity.HasKey(e => e.RateCode1).HasName("RateCodes$PrimaryKey");

            entity.HasIndex(e => e.RateCode1, "RateCodes$RateCode").IsUnique();

            entity.Property(e => e.RateCode1)
                .HasMaxLength(3)
                .HasColumnName("RateCode");
            entity.Property(e => e.Amount)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.Container).HasDefaultValue(false);
            entity.Property(e => e.ContainerCus)
                .HasDefaultValue(0.0)
                .HasColumnName("Container_Cus");
            entity.Property(e => e.DateCreated)
                .HasPrecision(0)
                .HasDefaultValueSql("(format(getdate(),'mm/dd/yy'))");
            entity.Property(e => e.DefaultRate)
                .HasMaxLength(1)
                .HasDefaultValue("N");
            entity.Property(e => e.Description).HasMaxLength(40);
            entity.Property(e => e.Edit).HasMaxLength(50);
            entity.Property(e => e.HourlyDesc).HasMaxLength(255);
            entity.Property(e => e.HourlyRate)
                .HasMaxLength(1)
                .HasDefaultValue("N");
            entity.Property(e => e.LastModified).HasPrecision(0);
            entity.Property(e => e.OneTimeRate).HasMaxLength(1);
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
            entity.Property(e => e.Taxable)
                .HasMaxLength(1)
                .HasDefaultValue("N");
        });

        modelBuilder.Entity<RateCodesWithoutMatchingDefaultRate>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("RateCodes Without Matching DefaultRates");

            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.Description).HasMaxLength(40);
            entity.Property(e => e.RateCode).HasMaxLength(3);
        });

        modelBuilder.Entity<RouteCode>(entity =>
        {
            entity.HasKey(e => e.RouteCode1).HasName("RouteCodes$PrimaryKey");

            entity.HasIndex(e => e.RouteCode1, "RouteCodes$Route Code").IsUnique();

            entity.Property(e => e.RouteCode1)
                .HasMaxLength(3)
                .HasColumnName("RouteCode");
            entity.Property(e => e.DateCreated)
                .HasPrecision(0)
                .HasDefaultValueSql("(format(getdate(),'mm/dd/yy'))");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.LastModified).HasPrecision(0);
        });

        modelBuilder.Entity<RouteCompare>(entity =>
        {
            entity.HasKey(e => e.Autonumber).HasName("Route Compare$PrimaryKey");

            entity.ToTable("Route Compare");

            entity.HasIndex(e => e.Autonumber, "Route Compare$Autonumber").IsUnique();

            entity.HasIndex(e => e.RouteCode, "Route Compare$RouteCode");

            entity.HasIndex(e => e.RouteStop, "Route Compare$RouteStop");

            entity.Property(e => e.CusNo).HasDefaultValue((short)0);
            entity.Property(e => e.RouteCode).HasMaxLength(3);
            entity.Property(e => e.RouteMin).HasDefaultValue(0);
            entity.Property(e => e.RouteStop).HasDefaultValue(0);
        });

        modelBuilder.Entity<RunningBalance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RunningBalance");

            entity.Property(e => e.Balance).HasMaxLength(255);
            entity.Property(e => e.CheckNo).HasMaxLength(12);
            entity.Property(e => e.Credit).HasMaxLength(255);
            entity.Property(e => e.Date).HasPrecision(0);
            entity.Property(e => e.Debit).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Tax).HasMaxLength(255);
            entity.Property(e => e.TransId)
                .HasMaxLength(255)
                .HasColumnName("TransID");
            entity.Property(e => e.Type).HasMaxLength(10);
        });

        modelBuilder.Entity<SelectFromRateCodesOrderByRateCode>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SELECT* FROM RateCodes ORDER BY RateCode");

            entity.Property(e => e.RateCode).HasMaxLength(3);
        });

        modelBuilder.Entity<SelectFromTypeCodesOrderByTypeCode>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SELECT* FROM TypeCodes ORDER BY TypeCode");

            entity.Property(e => e.TypeCode).HasMaxLength(1);
        });

        modelBuilder.Entity<SnapshotCu>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.Customer, "SnapshotCus$Customer");
        });

        modelBuilder.Entity<SumtmpPayment>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SumtmpPayments");

            entity.Property(e => e.SumOfAmount).HasColumnType("money");
        });

        modelBuilder.Entity<Tip>(entity =>
        {
            entity.HasKey(e => e.TipId).HasName("Tips$PrimaryKey");

            entity.HasIndex(e => e.TipId, "Tips$TipID");

            entity.Property(e => e.TipId).HasColumnName("TipID");
            entity.Property(e => e.Tip1)
                .HasMaxLength(255)
                .HasColumnName("Tip");
        });

        modelBuilder.Entity<TmpExpressPayment>(entity =>
        {
            entity.HasKey(e => e.TransId).HasName("tmpExpressPayments$PrimaryKey");

            entity.ToTable("tmpExpressPayments");

            entity.HasIndex(e => e.TransId, "tmpExpressPayments$TransID").IsUnique();

            entity.HasIndex(e => e.Type, "tmpExpressPayments$Type");

            entity.Property(e => e.TransId)
                .HasMaxLength(50)
                .HasColumnName("TransID");
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.CheckNumber).HasMaxLength(12);
            entity.Property(e => e.Date)
                .HasPrecision(0)
                .HasDefaultValueSql("(CONVERT([datetime],CONVERT([varchar],getdate(),(1)),(1)))");
            entity.Property(e => e.DateCreated)
                .HasPrecision(0)
                .HasDefaultValueSql("(format(getdate(),'mm/dd/yy'))");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.LastModified)
                .HasPrecision(0)
                .HasDefaultValueSql("(format(getdate(),'mm/dd/yy'))");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .HasDefaultValue("Payment");
        });

        modelBuilder.Entity<TotalCu>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TotalCus");
        });

        modelBuilder.Entity<TotalTip>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TotalTips");
        });

        modelBuilder.Entity<Trailer>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Trailer");

            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransId).HasName("Transactions$PrimaryKey");

            entity.HasIndex(e => e.CheckNo, "Transactions$CheckNum");

            entity.HasIndex(e => e.InvoiceNum, "Transactions$InvoiceNum");

            entity.HasIndex(e => e.RateCode, "Transactions$RateCode");

            entity.HasIndex(e => e.TransId, "Transactions$TransID");

            entity.HasIndex(e => e.Type, "Transactions$Type");

            entity.Property(e => e.TransId)
                .HasMaxLength(255)
                .HasColumnName("TransID");
            entity.Property(e => e.Amount)
                .HasDefaultValueSql("('$0.00')")
                .HasColumnType("money");
            entity.Property(e => e.CheckNo).HasMaxLength(12);
            entity.Property(e => e.ContainerDue)
                .HasPrecision(0)
                .HasColumnName("Container_Due");
            entity.Property(e => e.ContainerLoc)
                .HasMaxLength(50)
                .HasColumnName("Container_Loc");
            entity.Property(e => e.CusNo).HasDefaultValue(0);
            entity.Property(e => e.Date)
                .HasPrecision(0)
                .HasDefaultValueSql("(CONVERT([datetime],CONVERT([varchar],getdate(),(1)),(1)))");
            entity.Property(e => e.DateCreated)
                .HasPrecision(0)
                .HasDefaultValueSql("(format(getdate(),'mm/dd/yy'))");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.HoursWorked).HasDefaultValue(0.0);
            entity.Property(e => e.InvoiceNum).HasMaxLength(100);
            entity.Property(e => e.LastModified).HasPrecision(0);
            entity.Property(e => e.OrigAmount).HasColumnType("money");
            entity.Property(e => e.OrigFrequency).HasMaxLength(1);
            entity.Property(e => e.PaymentType).HasMaxLength(10);
            entity.Property(e => e.RateCode).HasMaxLength(3);
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
            entity.Property(e => e.TaxAmount).HasColumnType("money");
            entity.Property(e => e.Type).HasMaxLength(10);

            entity.HasOne(d => d.CusNoNavigation).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CusNo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Transactions$[C:\\armsls\\data\\armsdata.mde].{0283673D-7EB5-4F4D-B946-87C0F2C6C974}");

            entity.HasOne(d => d.RateCodeNavigation).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.RateCode)
                .HasConstraintName("Transactions$[C:\\armsls\\data\\armsdata.mde].{07621B72-7C2B-48F3-B7D8-049D21C1C4F3}");
        });

        modelBuilder.Entity<TypeCode>(entity =>
        {
            entity.HasKey(e => e.TypeCode1).HasName("TypeCodes$PrimaryKey");

            entity.HasIndex(e => e.TypeCode1, "TypeCodes$TypeCode");

            entity.Property(e => e.TypeCode1)
                .HasMaxLength(1)
                .HasColumnName("TypeCode");
            entity.Property(e => e.DateCreated)
                .HasPrecision(0)
                .HasDefaultValueSql("(format(getdate(),'mm/dd/yy'))");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Frequency).HasMaxLength(12);
            entity.Property(e => e.LastModified).HasPrecision(0);
            entity.Property(e => e.OpenInv).HasMaxLength(1);
        });

        modelBuilder.Entity<Weather>(entity =>
        {
            entity.HasKey(e => e.Date).HasName("Weather$PrimaryKey");

            entity.ToTable("Weather");

            entity.Property(e => e.Date)
                .HasPrecision(0)
                .HasDefaultValueSql("(format(getdate(),'mm/dd/yy'))");
            entity.Property(e => e.Condition).HasMaxLength(50);
            entity.Property(e => e.Day).HasMaxLength(9);
            entity.Property(e => e.Precip).HasMaxLength(4);
            entity.Property(e => e.Temperature).HasMaxLength(4);
            entity.Property(e => e.Time)
                .HasMaxLength(50)
                .HasDefaultValueSql("(format(getdate(),'Medium Time'))");
        });

        modelBuilder.Entity<WeatherStation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("WeatherStations$PrimaryKey");

            entity.HasIndex(e => e.City, "WeatherStations$City");

            entity.HasIndex(e => e.State, "WeatherStations$State");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.City).HasMaxLength(35);
            entity.Property(e => e.State).HasMaxLength(2);
        });

        modelBuilder.Entity<WeatherStations1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("WeatherStations1$PrimaryKey");

            entity.ToTable("WeatherStations1");

            entity.HasIndex(e => e.City, "WeatherStations1$City");

            entity.HasIndex(e => e.State, "WeatherStations1$State");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.City).HasMaxLength(35);
            entity.Property(e => e.State).HasMaxLength(2);
        });

        modelBuilder.Entity<ZipCode>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.AreaCode, "ZipCodes$AreaCode");

            entity.HasIndex(e => e.City, "ZipCodes$City");

            entity.HasIndex(e => e.Id, "ZipCodes$ID");

            entity.HasIndex(e => e.State, "ZipCodes$State");

            entity.HasIndex(e => e.Zip, "ZipCodes$Zip");

            entity.Property(e => e.AreaCode).HasMaxLength(3);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.County).HasMaxLength(100);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Lat).HasDefaultValue(0.0);
            entity.Property(e => e.Long).HasDefaultValue(0.0);
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
            entity.Property(e => e.State).HasMaxLength(2);
            entity.Property(e => e.TimeZone).HasMaxLength(1);
            entity.Property(e => e.Zip).HasMaxLength(5);
        });

        modelBuilder.Entity<_120Day>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("120 Days");

            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.Date).HasPrecision(0);
            entity.Property(e => e.DateCreated).HasPrecision(0);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.InvoiceNum).HasMaxLength(100);
            entity.Property(e => e.LastModified).HasPrecision(0);
            entity.Property(e => e.RateCode).HasMaxLength(3);
            entity.Property(e => e.TaxAmount).HasColumnType("money");
            entity.Property(e => e.TransId)
                .HasMaxLength(255)
                .HasColumnName("TransID");
            entity.Property(e => e.Type).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
