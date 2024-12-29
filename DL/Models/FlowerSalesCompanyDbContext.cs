using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Infrastructure;

namespace DL.Models;

public partial class FlowerSalesCompanyDbContext : DbContext
{
    public FlowerSalesCompanyDbContext()
    {
    }

    public FlowerSalesCompanyDbContext(DbContextOptions<FlowerSalesCompanyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accessory> Accessories { get; set; }

    public virtual DbSet<AccessoryProfitRate> AccessoryProfitRates { get; set; }

    public virtual DbSet<AccessoryProfitRateHistory> AccessoryProfitRateHistories { get; set; }

    public virtual DbSet<Allowance> Allowances { get; set; }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<BankAccount> BankAccounts { get; set; }

    public virtual DbSet<Bonus> Bonus { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerPromotionHistory> CustomerPromotionHistories { get; set; }

    public virtual DbSet<CustomerRank> CustomerRanks { get; set; }

    public virtual DbSet<CustomerRankHistory> CustomerRankHistories { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DetailedProduct> DetailedProducts { get; set; }

    public virtual DbSet<DetailedPurchaseOrder> DetailedPurchaseOrders { get; set; }

    public virtual DbSet<DetailedSalesOrder> DetailedSalesOrders { get; set; }

    public virtual DbSet<Emp> Emps { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeAllowance> EmployeeAllowances { get; set; }

    public virtual DbSet<EmployeeBonus> EmployeeBonus { get; set; }

    public virtual DbSet<EmployeeJobTitle> EmployeeJobTitles { get; set; }

    public virtual DbSet<EmployeePayrollHistory> EmployeePayrollHistories { get; set; }

    public virtual DbSet<FloralCharacteristic> FloralCharacteristics { get; set; }

    public virtual DbSet<FloralColor> FloralColors { get; set; }

    public virtual DbSet<FloralRepresentation> FloralRepresentations { get; set; }

    public virtual DbSet<FloralType> FloralTypes { get; set; }

    public virtual DbSet<Flower> Flowers { get; set; }

    public virtual DbSet<FlowerSalesTarget> FlowerSalesTargets { get; set; }

    public virtual DbSet<FlowerSalesTargetHistory> FlowerSalesTargetHistories { get; set; }

    public virtual DbSet<Form> Forms { get; set; }

    public virtual DbSet<FTEmployee> Ftemployees { get; set; }

    public virtual DbSet<GoodsDistribution> GoodsDistributions { get; set; }

    public virtual DbSet<ImmediateSalesOrder> ImmediateSalesOrders { get; set; }

    public virtual DbSet<JobTitle> JobTitles { get; set; }

    public virtual DbSet<Leave> Leaves { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MaterialInventory> MaterialInventories { get; set; }

    public virtual DbSet<OperatingExpenseHistory> OperatingExpenseHistories { get; set; }

    public virtual DbSet<OrderPromotionLevel> OrderPromotionLevels { get; set; }

    public virtual DbSet<Payroll> Payrolls { get; set; }

    public virtual DbSet<PreSalesOrder> PreSalesOrders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCreationHistory> ProductCreationHistories { get; set; }

    public virtual DbSet<ProductCreationPlanHistory> ProductCreationPlanHistories { get; set; }

    public virtual DbSet<ProductInventory> ProductInventories { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Ptemployee> Ptemployees { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<RankingCycle> RankingCycles { get; set; }

    public virtual DbSet<RankingCycleHistory> RankingCycleHistories { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<RevenueHistory> RevenueHistories { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<SalesOrder> SalesOrders { get; set; }

    public virtual DbSet<ShippingCompany> ShippingCompanies { get; set; }

    public virtual DbSet<ShippingInformation> ShippingInformations { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<StoreExpense> StoreExpenses { get; set; }

    public virtual DbSet<StoreExpenseHistory> StoreExpenseHistories { get; set; }

    public virtual DbSet<SyncStatus> SyncStatuses { get; set; }

    public virtual DbSet<TaxRate> TaxRates { get; set; }

    public virtual DbSet<TaxType> TaxTypes { get; set; }

    public virtual DbSet<UsedPromotionHistory> UsedPromotionHistories { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    public virtual DbSet<WorkShift> WorkShifts { get; set; }

    public virtual DbSet<WorkShiftDistribution> WorkShiftDistributions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        try
        {
            optionsBuilder.UseSqlServer(DbContextHelper.GetConnectionString("SQLServer"));
        }
        catch (Exception)
        {
            throw;
        }
    } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accessory>(entity =>
        {
            entity.HasKey(e => e.AccessoryId).HasName("PK__Accessor__09C3F0FB0995B282");

            entity.ToTable("Accessory");

            entity.Property(e => e.AccessoryId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AccessoryID");

            entity.HasOne(d => d.AccessoryNavigation).WithOne(p => p.Accessory)
                .HasForeignKey<Accessory>(d => d.AccessoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccessoryID_Accessory");
        });

        modelBuilder.Entity<AccessoryProfitRate>(entity =>
        {
            entity.HasKey(e => e.AccessoryProfitRateId).HasName("PK__Accessor__5B3C5C139C083EAA");

            entity.ToTable("AccessoryProfitRate");

            entity.Property(e => e.AccessoryProfitRateId).HasColumnName("AccessoryProfitRateID");
            entity.Property(e => e.UsageStatus).HasMaxLength(20);
        });

        modelBuilder.Entity<AccessoryProfitRateHistory>(entity =>
        {
            entity.HasKey(e => new { e.AccessoryProfitRateId, e.AccessoryId }).HasName("PK_Mutual_AccessoryProfitRateID_AccessoryID_AccessoryProfitRateHistory");

            entity.ToTable("AccessoryProfitRateHistory");

            entity.Property(e => e.AccessoryProfitRateId).HasColumnName("AccessoryProfitRateID");
            entity.Property(e => e.AccessoryId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AccessoryID");
            entity.Property(e => e.ProfitRate).HasColumnType("decimal(5, 1)");

            entity.HasOne(d => d.Accessory).WithMany(p => p.AccessoryProfitRateHistories)
                .HasForeignKey(d => d.AccessoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccessoryID_AccessoryProfitRateHistory");

            entity.HasOne(d => d.AccessoryProfitRate).WithMany(p => p.AccessoryProfitRateHistories)
                .HasForeignKey(d => d.AccessoryProfitRateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccessoryProfitRateID_AccessoryProfitRateHistory");
        });

        modelBuilder.Entity<Allowance>(entity =>
        {
            entity.HasKey(e => e.AllowanceId).HasName("PK__Allowanc__7B12D04196E15972");

            entity.ToTable("Allowance");

            entity.Property(e => e.AllowanceId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AllowanceID");
            entity.Property(e => e.AllowanceName).HasMaxLength(50);
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 0)");
        });

        modelBuilder.Entity<Bank>(entity =>
        {
            entity.HasKey(e => e.BankId).HasName("PK__Bank__AA08CB33733740E4");

            entity.ToTable("Bank");

            entity.Property(e => e.BankId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("BankID");
            entity.Property(e => e.BankName).HasMaxLength(100);
        });

        modelBuilder.Entity<BankAccount>(entity =>
        {
            entity.HasKey(e => e.BankAccountId).HasName("PK__BankAcco__4FC8E7411CEFDB96");

            entity.ToTable("BankAccount");

            entity.Property(e => e.BankAccountId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BankAccountID");
            entity.Property(e => e.BankAccountNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BankId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("BankID");

            entity.HasOne(d => d.Bank).WithMany(p => p.BankAccounts)
                .HasForeignKey(d => d.BankId)
                .HasConstraintName("FK_BankID_BankAccount");
        });

        modelBuilder.Entity<Bonus>(entity =>
        {
            entity.HasKey(e => e.BonusId).HasName("PK__Bonus__8E554708BB47F7BC");

            entity.Property(e => e.BonusId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("BonusID");
            entity.Property(e => e.BonusName).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B805A3FC49");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CustomerID");
            entity.Property(e => e.CustomerAddress).HasMaxLength(255);
            entity.Property(e => e.CustomerType).HasMaxLength(20);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(3);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(11)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CustomerPromotionHistory>(entity =>
        {
            entity.HasKey(e => new { e.PromotionId, e.CustomerRankId }).HasName("PK_Mutual_PromotionID_CustomerRankID_CustomerPromotionHistory");

            entity.ToTable("CustomerPromotionHistory");

            entity.Property(e => e.PromotionId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PromotionID");
            entity.Property(e => e.CustomerRankId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CustomerRankID");
            entity.Property(e => e.Discount).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.MaximumDiscountValue).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.MinimumBasePrice).HasColumnType("decimal(18, 3)");

            entity.HasOne(d => d.CustomerRank).WithMany(p => p.CustomerPromotionHistories)
                .HasForeignKey(d => d.CustomerRankId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerRankID_CustomerPromotionHistory");

            entity.HasOne(d => d.Promotion).WithMany(p => p.CustomerPromotionHistories)
                .HasForeignKey(d => d.PromotionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PromotionID_CustomerPromotionHistory");
        });

        modelBuilder.Entity<CustomerRank>(entity =>
        {
            entity.HasKey(e => e.CustomerRankId).HasName("PK__Customer__A067843224581D02");

            entity.ToTable("CustomerRank");

            entity.Property(e => e.CustomerRankId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CustomerRankID");
            entity.Property(e => e.RankName).HasMaxLength(20);
        });

        modelBuilder.Entity<CustomerRankHistory>(entity =>
        {
            entity.HasKey(e => e.CustomerRankHistoryId).HasName("PK__Customer__BA6404DE868888DA");

            entity.ToTable("CustomerRankHistory");

            entity.Property(e => e.CustomerRankHistoryId).HasColumnName("CustomerRankHistoryID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CustomerID");
            entity.Property(e => e.CustomerRankId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CustomerRankID");
            entity.Property(e => e.RankingCycleId).HasColumnName("RankingCycleID");
            entity.Property(e => e.TotalSpending).HasColumnType("decimal(38, 3)");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerRankHistories)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CustomerID_CustomerRankHistory");

            entity.HasOne(d => d.CustomerRank).WithMany(p => p.CustomerRankHistories)
                .HasForeignKey(d => d.CustomerRankId)
                .HasConstraintName("FK_CustomerRankID_CustomerRankHistory");

            entity.HasOne(d => d.RankingCycle).WithMany(p => p.CustomerRankHistories)
                .HasForeignKey(d => d.RankingCycleId)
                .HasConstraintName("FK_RankingCycleID_CustomerRankHistory");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCD72D1FAAD");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName).HasMaxLength(50);
        });

        modelBuilder.Entity<DetailedProduct>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.MaterialId }).HasName("PK_Mutual_ProductID_MaterialID_DetailedProduct");

            entity.ToTable("DetailedProduct");

            entity.Property(e => e.ProductId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ProductID");
            entity.Property(e => e.MaterialId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaterialID");

            entity.HasOne(d => d.Material).WithMany(p => p.DetailedProducts)
                .HasForeignKey(d => d.MaterialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaterialID_DetailedProduct");

            entity.HasOne(d => d.Product).WithMany(p => p.DetailedProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductID_DetailedProduct");
        });

        modelBuilder.Entity<DetailedPurchaseOrder>(entity =>
        {
            entity.HasKey(e => new { e.PurchaseOrderId, e.MaterialId }).HasName("PK_Mutual_PurchaseOrderID_MaterialID_DetailedPurchaseOrder");

            entity.ToTable("DetailedPurchaseOrder");

            entity.Property(e => e.PurchaseOrderId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PurchaseOrderID");
            entity.Property(e => e.MaterialId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaterialID");
            entity.Property(e => e.CostPrice).HasColumnType("decimal(20, 3)");

            entity.HasOne(d => d.Material).WithMany(p => p.DetailedPurchaseOrders)
                .HasForeignKey(d => d.MaterialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaterialID_DetailedPurchaseOrder");

            entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.DetailedPurchaseOrders)
                .HasForeignKey(d => d.PurchaseOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseOrderID_DetailedPurchaseOrder");
        });

        modelBuilder.Entity<DetailedSalesOrder>(entity =>
        {
            entity.HasKey(e => new { e.SalesOrderId, e.ProductId }).HasName("PK_Mutual_SalesOrderID_ProductID_DetailedSalesOrder");

            entity.ToTable("DetailedSalesOrder");

            entity.Property(e => e.SalesOrderId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SalesOrderID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.DetailedSalesOrders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductID_DetailedSalesOrder");

            entity.HasOne(d => d.SalesOrder).WithMany(p => p.DetailedSalesOrders)
                .HasForeignKey(d => d.SalesOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesOrderID_DetailedSalesOrder");
        });

        modelBuilder.Entity<Emp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("emp");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF1F53C04BC");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.BankAccountId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BankAccountID");
            entity.Property(e => e.CitizenId)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CitizenID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeAddress).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(3);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.TaxId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("TaxID");
            entity.Property(e => e.WorkType)
                .HasMaxLength(9)
                .IsUnicode(false);

            entity.HasOne(d => d.BankAccount).WithMany(p => p.Employees)
                .HasForeignKey(d => d.BankAccountId)
                .HasConstraintName("FK_BankAccountID_Employee");
        });

        modelBuilder.Entity<EmployeeAllowance>(entity =>
        {
            entity.HasKey(e => new { e.EmployeeId, e.AllowanceId }).HasName("PK_Mutual_EmployeeID_AllowanceID_EmployeeAllowance");

            entity.ToTable("EmployeeAllowance");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.AllowanceId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AllowanceID");

            entity.HasOne(d => d.Allowance).WithMany(p => p.EmployeeAllowances)
                .HasForeignKey(d => d.AllowanceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AllowanceID_EmployeeAllowance");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeAllowances)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeID_EmployeeAllowance");
        });

        modelBuilder.Entity<EmployeeBonus>(entity =>
        {
            entity.HasKey(e => new { e.EmployeeId, e.BonusId }).HasName("PK_EmployeeID_BonusID_EmployeeBonus");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.BonusId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("BonusID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 0)");

            entity.HasOne(d => d.Bonus).WithMany(p => p.EmployeeBonus)
                .HasForeignKey(d => d.BonusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BonusID_EmployeeBonus");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeBonus)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeID_EmployeeBonus");
        });

        modelBuilder.Entity<EmployeeJobTitle>(entity =>
        {
            entity.HasKey(e => new { e.EmployeeId, e.JobTitleId }).HasName("PK_Mutual_EmployeeID_JobTitleID_EmployeeJobTitle");

            entity.ToTable("EmployeeJobTitle");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.JobTitleId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("JobTitleID");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeJobTitles)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeID_EmployeeJobTitle");

            entity.HasOne(d => d.JobTitle).WithMany(p => p.EmployeeJobTitles)
                .HasForeignKey(d => d.JobTitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobTitleID_EmployeeJobTitle");
        });

        modelBuilder.Entity<EmployeePayrollHistory>(entity =>
        {
            entity.HasKey(e => new { e.PeriodId, e.EmployeeId }).HasName("PK_Mutual_PeriodID_EmployeeID_EmployeePayrollHistory");

            entity.ToTable("EmployeePayrollHistory");

            entity.Property(e => e.PeriodId).HasColumnName("PeriodID");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Income).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.TaxRateId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TaxRateID");
            entity.Property(e => e.TotalAllowance).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.TotalBonus).HasColumnType("decimal(10, 3)");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeePayrollHistories)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeID_EmployeePayrollHistory");

            entity.HasOne(d => d.Period).WithMany(p => p.EmployeePayrollHistories)
                .HasForeignKey(d => d.PeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PeriodID_EmployeePayrollHistory");

            entity.HasOne(d => d.TaxRate).WithMany(p => p.EmployeePayrollHistories)
                .HasForeignKey(d => d.TaxRateId)
                .HasConstraintName("FK_TaxRateID_EmployeePayrollHistory");
        });

        modelBuilder.Entity<FloralCharacteristic>(entity =>
        {
            entity.HasKey(e => e.FcharacteristicId).HasName("PK__FloralCh__F37B7963BC100DE6");

            entity.ToTable("FloralCharacteristic");

            entity.Property(e => e.FcharacteristicId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FCharacteristicID");
            entity.Property(e => e.CharacteristicName).HasMaxLength(4);
        });

        modelBuilder.Entity<FloralColor>(entity =>
        {
            entity.HasKey(e => e.FcolorId).HasName("PK__FloralCo__F4850EE38DE2FD64");

            entity.ToTable("FloralColor");

            entity.Property(e => e.FcolorId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FColorID");
            entity.Property(e => e.ColorName).HasMaxLength(10);
        });

        modelBuilder.Entity<FloralRepresentation>(entity =>
        {
            entity.HasKey(e => e.FrepresentationId).HasName("PK__FloralRe__A3BE2125A8E52D74");

            entity.ToTable("FloralRepresentation");

            entity.Property(e => e.FrepresentationId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FRepresentationID");
            entity.Property(e => e.Frname)
                .HasMaxLength(5)
                .HasColumnName("FRName");
        });

        modelBuilder.Entity<FloralType>(entity =>
        {
            entity.HasKey(e => e.FtypeId).HasName("PK__FloralTy__9B12C653CA033EAE");

            entity.ToTable("FloralType");

            entity.Property(e => e.FtypeId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FTypeID");
            entity.Property(e => e.TypeName).HasMaxLength(20);
        });

        modelBuilder.Entity<Flower>(entity =>
        {
            entity.HasKey(e => e.FlowerId).HasName("PK__Flower__97C47C39F4F4A23E");

            entity.ToTable("Flower");

            entity.Property(e => e.FlowerId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FlowerID");
            entity.Property(e => e.FcharacteristicId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FCharacteristicID");
            entity.Property(e => e.FcolorId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FColorID");
            entity.Property(e => e.FtypeId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FTypeID");

            entity.HasOne(d => d.Fcharacteristic).WithMany(p => p.Flowers)
                .HasForeignKey(d => d.FcharacteristicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FCharacteristicID_Flower");

            entity.HasOne(d => d.Fcolor).WithMany(p => p.Flowers)
                .HasForeignKey(d => d.FcolorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FColorID_Flower");

            entity.HasOne(d => d.FlowerNavigation).WithOne(p => p.Flower)
                .HasForeignKey<Flower>(d => d.FlowerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FlowerID_Flower");

            entity.HasOne(d => d.Ftype).WithMany(p => p.Flowers)
                .HasForeignKey(d => d.FtypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FTypeID_Flower");
        });

        modelBuilder.Entity<FlowerSalesTarget>(entity =>
        {
            entity.HasKey(e => e.TargetId).HasName("PK__FlowerSa__2B1F0FB61DD0F759");

            entity.ToTable("FlowerSalesTarget");

            entity.HasIndex(e => new { e.ApplyMonth, e.ApplyYear }, "UQ_ApplyMonth_ApplyYear_FlowerSalesTarget").IsUnique();

            entity.Property(e => e.TargetId).HasColumnName("TargetID");
            entity.Property(e => e.ApplyMonth).HasColumnType("decimal(2, 0)");
            entity.Property(e => e.ApplyYear).HasColumnType("decimal(4, 0)");
            entity.Property(e => e.UsageStatus).HasMaxLength(20);
        });

        modelBuilder.Entity<FlowerSalesTargetHistory>(entity =>
        {
            entity.HasKey(e => new { e.TargetId, e.FlowerId }).HasName("PK_Mutual_TargetID_FlowerID_FlowerSalesTargetHistory");

            entity.ToTable("FlowerSalesTargetHistory");

            entity.Property(e => e.TargetId).HasColumnName("TargetID");
            entity.Property(e => e.FlowerId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FlowerID");
            entity.Property(e => e.ProfitRate).HasColumnType("decimal(5, 1)");

            entity.HasOne(d => d.Flower).WithMany(p => p.FlowerSalesTargetHistories)
                .HasForeignKey(d => d.FlowerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FlowerID_FlowerSalesTargetHistory");

            entity.HasOne(d => d.Target).WithMany(p => p.FlowerSalesTargetHistories)
                .HasForeignKey(d => d.TargetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TargetID_FlowerSalesTargetHistory");
        });

        modelBuilder.Entity<Form>(entity =>
        {
            entity.HasKey(e => e.FormId).HasName("PK__Form__FB05B7BD68853EBA");

            entity.ToTable("Form");

            entity.Property(e => e.FormId).HasColumnName("FormID");
            entity.Property(e => e.FormName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FTEmployee>(entity =>
        {
            entity.HasKey(e => e.FTEmployeeID).HasName("PK__FTEmploy__8783797B080A58F3");

            entity.ToTable("FTEmployee");

            entity.Property(e => e.FTEmployeeID)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FTEmployeeID");
            entity.Property(e => e.SalaryId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SalaryID");

            entity.HasOne(d => d.FtemployeeNavigation).WithOne(p => p.Ftemployee)
                .HasForeignKey<FTEmployee>(d => d.FTEmployeeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FTEmployeeID_FTEmployee");

            entity.HasOne(d => d.Salary).WithMany(p => p.Ftemployees)
                .HasForeignKey(d => d.SalaryId)
                .HasConstraintName("FK_SalaryID_FTEmployee");
        });

        modelBuilder.Entity<GoodsDistribution>(entity =>
        {
            entity.HasKey(e => new { e.PurchaseOrderId, e.StoreId, e.MaterialId }).HasName("PK_Mutual_PurchaseOrderID_StoreID_MaterialID_Inventory");

            entity.ToTable("GoodsDistribution");

            entity.Property(e => e.PurchaseOrderId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PurchaseOrderID");
            entity.Property(e => e.StoreId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("StoreID");
            entity.Property(e => e.MaterialId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaterialID");

            entity.HasOne(d => d.Material).WithMany(p => p.GoodsDistributions)
                .HasForeignKey(d => d.MaterialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaterialID_GoodsDistribution");

            entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.GoodsDistributions)
                .HasForeignKey(d => d.PurchaseOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseOrderID_GoodsDistribution");

            entity.HasOne(d => d.Store).WithMany(p => p.GoodsDistributions)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoreID_GoodsDistribution");
        });

        modelBuilder.Entity<ImmediateSalesOrder>(entity =>
        {
            entity.HasKey(e => e.IsalesOrderId).HasName("PK__Immediat__68248900D9334A98");

            entity.ToTable("ImmediateSalesOrder");

            entity.Property(e => e.IsalesOrderId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISalesOrderID");

            entity.HasOne(d => d.IsalesOrder).WithOne(p => p.ImmediateSalesOrder)
                .HasForeignKey<ImmediateSalesOrder>(d => d.IsalesOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ISalesOrderID_ImmediateSalesOrder");
        });

        modelBuilder.Entity<JobTitle>(entity =>
        {
            entity.HasKey(e => e.JobTitleId).HasName("PK__JobTitle__35382FC9293E5893");

            entity.ToTable("JobTitle");

            entity.Property(e => e.JobTitleId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("JobTitleID");
            entity.Property(e => e.DepartmentId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DepartmentID");
            entity.Property(e => e.FormId).HasColumnName("FormID");
            entity.Property(e => e.Jd).HasColumnName("JD");
            entity.Property(e => e.JobTitleName).HasMaxLength(50);

            entity.HasOne(d => d.Department).WithMany(p => p.JobTitles)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_DepartmentID_JobTitle");

            entity.HasOne(d => d.Form).WithMany(p => p.JobTitles)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("FK_FormID_JobTitle");
        });

        modelBuilder.Entity<Leave>(entity =>
        {
            entity.HasKey(e => e.Leave1).HasName("PK__Leave__A0F02A31CFDF2F7D");

            entity.ToTable("Leave");

            entity.Property(e => e.Leave1)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Leave");
            entity.Property(e => e.FtemployeeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FTEmployeeID");
            entity.Property(e => e.Reason).HasMaxLength(50);

            entity.HasOne(d => d.Ftemployee).WithMany(p => p.Leaves)
                .HasForeignKey(d => d.FtemployeeId)
                .HasConstraintName("FK_FTEmployeeID_Leave");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("PK__Material__C5061317E655AD03");

            entity.ToTable("Material");

            entity.Property(e => e.MaterialId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaterialID");
            entity.Property(e => e.MaterialName).HasMaxLength(50);
            entity.Property(e => e.MaterialType).HasMaxLength(10);
            entity.Property(e => e.Unit).HasMaxLength(10);
        });

        modelBuilder.Entity<MaterialInventory>(entity =>
        {
            entity.HasKey(e => new { e.StoreId, e.MaterialId }).HasName("PK_Mutual_StoreID_MaterialID_MaterialInventory");

            entity.ToTable("MaterialInventory");

            entity.Property(e => e.StoreId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("StoreID");
            entity.Property(e => e.MaterialId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaterialID");

            entity.HasOne(d => d.Material).WithMany(p => p.MaterialInventories)
                .HasForeignKey(d => d.MaterialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaterialID_MaterialInventory");

            entity.HasOne(d => d.Store).WithMany(p => p.MaterialInventories)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoreID_MaterialInventory");
        });

        modelBuilder.Entity<OperatingExpenseHistory>(entity =>
        {
            entity.HasKey(e => e.OperatingExpenseId).HasName("PK__Operatin__C650CA0592125636");

            entity.ToTable("OperatingExpenseHistory");

            entity.HasIndex(e => new { e.ReportingMonth, e.ReportingYear }, "UQ_ReportingMonth_ReportingYear_OperatingExpenseHistory").IsUnique();

            entity.Property(e => e.OperatingExpenseId).HasColumnName("OperatingExpenseID");
            entity.Property(e => e.ReportingMonth).HasColumnType("decimal(2, 0)");
            entity.Property(e => e.ReportingYear).HasColumnType("decimal(4, 0)");
            entity.Property(e => e.TotalExpense).HasColumnType("decimal(38, 3)");
        });

        modelBuilder.Entity<OrderPromotionLevel>(entity =>
        {
            entity.HasKey(e => e.OplevelId).HasName("PK__OrderPro__ED1EF84A5EA68097");

            entity.ToTable("OrderPromotionLevel");

            entity.Property(e => e.OplevelId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("OPLevelID");
            entity.Property(e => e.Discount).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.MaximumDiscountValue).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.MininumBasePrice).HasColumnType("decimal(18, 3)");
        });

        modelBuilder.Entity<Payroll>(entity =>
        {
            entity.HasKey(e => e.PeriodId).HasName("PK__Payroll__E521BB36182CAD7D");

            entity.ToTable("Payroll");

            entity.HasIndex(e => new { e.PayrollMonth, e.PayrollYear }, "UQ_PayrollMonth_PayrollYear_Payroll").IsUnique();

            entity.Property(e => e.PeriodId).HasColumnName("PeriodID");
            entity.Property(e => e.PayrollMonth).HasColumnType("decimal(2, 0)");
            entity.Property(e => e.PayrollYear).HasColumnType("decimal(4, 0)");
        });

        modelBuilder.Entity<PreSalesOrder>(entity =>
        {
            entity.HasKey(e => e.PreSalesOrderId).HasName("PK__PreSales__B258616698634FF5");

            entity.ToTable("PreSalesOrder");

            entity.Property(e => e.PreSalesOrderId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PreSalesOrderID");

            entity.HasOne(d => d.PreSalesOrderNavigation).WithOne(p => p.PreSalesOrder)
                .HasForeignKey<PreSalesOrder>(d => d.PreSalesOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PreSalesOrderID_PreSalesOrder");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6ED7D8BCFD5");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ProductID");
            entity.Property(e => e.FrepresentationId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FRepresentationID");
            entity.Property(e => e.ProductName).HasMaxLength(50);

            entity.HasOne(d => d.Frepresentation).WithMany(p => p.Products)
                .HasForeignKey(d => d.FrepresentationId)
                .HasConstraintName("FK_FRepresentationID_Product");
        });

        modelBuilder.Entity<ProductCreationHistory>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.EmployeeId, e.CreatedDateTime }).HasName("PK_Mutual_ProductID_EmployeeID_CreatedDateTime_ProductCreationHistory");

            entity.ToTable("ProductCreationHistory");

            entity.Property(e => e.ProductId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ProductID");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 0)");

            entity.HasOne(d => d.Employee).WithMany(p => p.ProductCreationHistories)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeID_ProductCreationHistory");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductCreationHistories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductID_ProductCreationHistory");
        });

        modelBuilder.Entity<ProductCreationPlanHistory>(entity =>
        {
            entity.HasKey(e => new { e.PlannedDateTime, e.StoreId, e.ProductId }).HasName("PK_Mutual_PlannedDatetime_StoreID_ProductID_ProductCreationPlanHistory");

            entity.ToTable("ProductCreationPlanHistory");

            entity.Property(e => e.StoreId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("StoreID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ProductID");
            entity.Property(e => e.PlanStatus).HasMaxLength(20);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductCreationPlanHistories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductID_ProductCreationPlanHistory");

            entity.HasOne(d => d.Store).WithMany(p => p.ProductCreationPlanHistories)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoreID_ProductCreationPlanHistory");
        });

        modelBuilder.Entity<ProductInventory>(entity =>
        {
            entity.HasKey(e => new { e.StoreId, e.ProductId, e.StockDate }).HasName("PK_Mutual_StoreID_ProductID_StockDate_ProductInventory");

            entity.ToTable("ProductInventory");

            entity.Property(e => e.StoreId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("StoreID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductInventories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductID_ProductInventory");

            entity.HasOne(d => d.Store).WithMany(p => p.ProductInventories)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoreID_ProductInventory");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK__Promotio__52C42F2F5206C849");

            entity.ToTable("Promotion");

            entity.Property(e => e.PromotionId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PromotionID");
            entity.Property(e => e.PromotionName).HasMaxLength(50);
            entity.Property(e => e.PromotionType).HasMaxLength(10);
            entity.Property(e => e.UsageStatus).HasMaxLength(20);

            entity.HasMany(d => d.Oplevels).WithMany(p => p.Promotions)
                .UsingEntity<Dictionary<string, object>>(
                    "OrderPromotionHistory",
                    r => r.HasOne<OrderPromotionLevel>().WithMany()
                        .HasForeignKey("OplevelId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_OPLevelID_OrderPromotionHistory"),
                    l => l.HasOne<Promotion>().WithMany()
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PromotionID_OrderPromotionHistory"),
                    j =>
                    {
                        j.HasKey("PromotionId", "OplevelId").HasName("PK_Mutual_PromotionID_OPLevelID_OrderPromotionHistory");
                        j.ToTable("OrderPromotionHistory");
                        j.IndexerProperty<string>("PromotionId")
                            .HasMaxLength(10)
                            .IsUnicode(false)
                            .IsFixedLength()
                            .HasColumnName("PromotionID");
                        j.IndexerProperty<string>("OplevelId")
                            .HasMaxLength(10)
                            .IsUnicode(false)
                            .IsFixedLength()
                            .HasColumnName("OPLevelID");
                    });
        });

        modelBuilder.Entity<Ptemployee>(entity =>
        {
            entity.HasKey(e => e.PtemployeeId).HasName("PK__PTEmploy__E92056B523D46B25");

            entity.ToTable("PTEmployee");

            entity.Property(e => e.PtemployeeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PTEmployeeID");
            entity.Property(e => e.StoreId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("StoreID");

            entity.HasOne(d => d.PtemployeeNavigation).WithOne(p => p.Ptemployee)
                .HasForeignKey<Ptemployee>(d => d.PtemployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PTEmployeeID_PTEmployee");

            entity.HasOne(d => d.Store).WithMany(p => p.Ptemployees)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("FK_StoreID_PTEmployee");
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.PurchaseOrderId).HasName("PK__Purchase__036BAC44FCD4B75A");

            entity.ToTable("PurchaseOrder");

            entity.Property(e => e.PurchaseOrderId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PurchaseOrderID");
            entity.Property(e => e.OrderType).HasMaxLength(8);
            entity.Property(e => e.TotalCost).HasColumnType("decimal(38, 3)");
            entity.Property(e => e.VendorId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("VendorID");

            entity.HasOne(d => d.Vendor).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("FK_VendorID_PurchaseOrder");
        });

        modelBuilder.Entity<RankingCycle>(entity =>
        {
            entity.HasKey(e => e.RankingCycleId).HasName("PK__RankingC__1B23C188FBEEAF28");

            entity.ToTable("RankingCycle");

            entity.Property(e => e.RankingCycleId).HasColumnName("RankingCycleID");
            entity.Property(e => e.UsageStatus).HasMaxLength(20);
        });

        modelBuilder.Entity<RankingCycleHistory>(entity =>
        {
            entity.HasKey(e => new { e.RankingCycleId, e.CustomerRankId }).HasName("PK_Mutual_RankingCycleID_CustomerRankID_RankingCycleHistory");

            entity.ToTable("RankingCycleHistory");

            entity.Property(e => e.RankingCycleId).HasColumnName("RankingCycleID");
            entity.Property(e => e.CustomerRankId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CustomerRankID");
            entity.Property(e => e.MinimumSpending).HasColumnType("decimal(10, 0)");

            entity.HasOne(d => d.CustomerRank).WithMany(p => p.RankingCycleHistories)
                .HasForeignKey(d => d.CustomerRankId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerRankID_RankingCycleHistory");

            entity.HasOne(d => d.RankingCycle).WithMany(p => p.RankingCycleHistories)
                .HasForeignKey(d => d.RankingCycleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RankingCycleID_RankingCycleHistory");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionId).HasName("PK__Region__ACD8444385A284D7");

            entity.ToTable("Region");

            entity.Property(e => e.RegionId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("RegionID");
            entity.Property(e => e.RegionName).HasMaxLength(50);
        });

        modelBuilder.Entity<RevenueHistory>(entity =>
        {
            entity.HasKey(e => e.RevenueId).HasName("PK__RevenueH__275F173D25424025");

            entity.ToTable("RevenueHistory");

            entity.HasIndex(e => new { e.ReportingMonth, e.ReportingYear }, "UQ_ReportingMonth_ReportingYear_RevenueHistory").IsUnique();

            entity.Property(e => e.RevenueId).HasColumnName("RevenueID");
            entity.Property(e => e.ExpectedFlowerRevenue).HasColumnType("decimal(38, 3)");
            entity.Property(e => e.NetFlowerRevenue).HasColumnType("decimal(38, 3)");
            entity.Property(e => e.NetSuppMaterialRevenue).HasColumnType("decimal(38, 3)");
            entity.Property(e => e.ReportingMonth).HasColumnType("decimal(2, 0)");
            entity.Property(e => e.ReportingYear).HasColumnType("decimal(4, 0)");
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.SalaryId).HasName("PK__Salary__4BE204B7F2999763");

            entity.ToTable("Salary");

            entity.Property(e => e.SalaryId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SalaryID");
            entity.Property(e => e.BaseSalary).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.SalaryCoefficient).HasColumnType("decimal(5, 1)");
        });

        modelBuilder.Entity<SalesOrder>(entity =>
        {
            entity.HasKey(e => e.SalesOrderId).HasName("PK__SalesOrd__B14003C23DAC6F5E");

            entity.ToTable("SalesOrder");

            entity.Property(e => e.SalesOrderId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SalesOrderID");
            entity.Property(e => e.BasePrice).HasColumnType("decimal(38, 3)");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CustomerID");
            entity.Property(e => e.FinalPrice).HasColumnType("decimal(38, 3)");
            entity.Property(e => e.OrderStatus).HasMaxLength(10);
            entity.Property(e => e.OrderType).HasMaxLength(20);
            entity.Property(e => e.PurchaseMethod).HasMaxLength(20);
            entity.Property(e => e.StoreId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("StoreID");

            entity.HasOne(d => d.Customer).WithMany(p => p.SalesOrders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CustomerID_SalesOrder");

            entity.HasOne(d => d.Store).WithMany(p => p.SalesOrders)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("FK_StoreID_SalesOrder");
        });

        modelBuilder.Entity<ShippingCompany>(entity =>
        {
            entity.HasKey(e => e.ShippingCompanyId).HasName("PK__Shipping__DADC8F9A091730D3");

            entity.ToTable("ShippingCompany");

            entity.Property(e => e.ShippingCompanyId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ShippingCompanyID");
            entity.Property(e => e.ShippingCompanyName).HasMaxLength(50);
        });

        modelBuilder.Entity<ShippingInformation>(entity =>
        {
            entity.HasKey(e => e.ShippingId).HasName("PK__Shipping__5FACD4600A3BC48B");

            entity.ToTable("ShippingInformation");

            entity.Property(e => e.ShippingId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ShippingID");
            entity.Property(e => e.CityProvince)
                .HasMaxLength(50)
                .HasColumnName("City/Province");
            entity.Property(e => e.ConsigneeName).HasMaxLength(50);
            entity.Property(e => e.ConsigneePhoneNumber)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.District).HasMaxLength(50);
            entity.Property(e => e.SalesOrderId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SalesOrderID");
            entity.Property(e => e.ShippingAddress).HasMaxLength(255);
            entity.Property(e => e.ShippingCompanyId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ShippingCompanyID");
            entity.Property(e => e.ShippingCost).HasColumnType("decimal(9, 3)");

            entity.HasOne(d => d.SalesOrder).WithMany(p => p.ShippingInformations)
                .HasForeignKey(d => d.SalesOrderId)
                .HasConstraintName("FK_SalesOrderID_ShippingInformation");

            entity.HasOne(d => d.ShippingCompany).WithMany(p => p.ShippingInformations)
                .HasForeignKey(d => d.ShippingCompanyId)
                .HasConstraintName("FK_ShippingCompanyID_ShippingInformation");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PK__Store__3B82F0E105FDF5DF");

            entity.ToTable("Store");

            entity.Property(e => e.StoreId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("StoreID");
            entity.Property(e => e.ManagerId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ManagerID");
            entity.Property(e => e.RegionId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("RegionID");
            entity.Property(e => e.StoreAddress).HasMaxLength(255);
            entity.Property(e => e.StoreName).HasMaxLength(50);

            entity.HasOne(d => d.Manager).WithMany(p => p.Stores)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_ManagerID_Store");

            entity.HasOne(d => d.Region).WithMany(p => p.Stores)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("FK_RegionID_Store");
        });

        modelBuilder.Entity<StoreExpense>(entity =>
        {
            entity.HasKey(e => e.StoreExpenseId).HasName("PK__StoreExp__5C097E0B396EC27A");

            entity.ToTable("StoreExpense");

            entity.Property(e => e.StoreExpenseId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("StoreExpenseID");
            entity.Property(e => e.PaymentCycle).HasMaxLength(10);
            entity.Property(e => e.StoreExpenseName).HasMaxLength(50);
        });

        modelBuilder.Entity<StoreExpenseHistory>(entity =>
        {
            entity.HasKey(e => new { e.StoreExpenseId, e.StoreId }).HasName("PK_Mutual_StoreExpenseID_StoreID_StoreExpenseHistory");

            entity.ToTable("StoreExpenseHistory");

            entity.Property(e => e.StoreExpenseId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("StoreExpenseID");
            entity.Property(e => e.StoreId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("StoreID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 3)");

            entity.HasOne(d => d.StoreExpense).WithMany(p => p.StoreExpenseHistories)
                .HasForeignKey(d => d.StoreExpenseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoreExpenseID_StoreExpenseHistory");

            entity.HasOne(d => d.Store).WithMany(p => p.StoreExpenseHistories)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoreID_StoreExpenseHistory");
        });

        modelBuilder.Entity<SyncStatus>(entity =>
        {
            entity.HasKey(e => e.TableName).HasName("PK__SyncStat__733652EFFC1D55A2");

            entity.ToTable("SyncStatus");

            entity.Property(e => e.TableName).HasMaxLength(100);
            entity.Property(e => e.LastSyncTime).HasDefaultValueSql("(switchoffset(sysdatetimeoffset(),'+07:00'))");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<TaxRate>(entity =>
        {
            entity.HasKey(e => e.TaxRateId).HasName("PK__TaxRate__B114CEE1A4CE3FE3");

            entity.ToTable("TaxRate");

            entity.Property(e => e.TaxRateId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TaxRateID");
            entity.Property(e => e.ConditionDescription).HasMaxLength(255);
            entity.Property(e => e.Rate).HasColumnType("decimal(6, 3)");
            entity.Property(e => e.TaxTypeId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TaxTypeID");

            entity.HasOne(d => d.TaxType).WithMany(p => p.TaxRates)
                .HasForeignKey(d => d.TaxTypeId)
                .HasConstraintName("FK_TaxTypeID_TaxRate");
        });

        modelBuilder.Entity<TaxType>(entity =>
        {
            entity.HasKey(e => e.TaxTypeId).HasName("PK__TaxType__B5343F6323041FD2");

            entity.ToTable("TaxType");

            entity.Property(e => e.TaxTypeId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TaxTypeID");
            entity.Property(e => e.TaxTypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<UsedPromotionHistory>(entity =>
        {
            entity.HasKey(e => new { e.PromotionId, e.SalesOrderId }).HasName("PK_Mutual_PromotionID_SalesOrderID_UsedPromotionHistory");

            entity.ToTable("UsedPromotionHistory");

            entity.Property(e => e.PromotionId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PromotionID");
            entity.Property(e => e.SalesOrderId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SalesOrderID");
            entity.Property(e => e.CustomerDiscountValue).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.OrderDiscountValue).HasColumnType("decimal(18, 3)");

            entity.HasOne(d => d.Promotion).WithMany(p => p.UsedPromotionHistories)
                .HasForeignKey(d => d.PromotionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PromotionID_UsedPromotionHistory");

            entity.HasOne(d => d.SalesOrder).WithMany(p => p.UsedPromotionHistories)
                .HasForeignKey(d => d.SalesOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesOrderID_UsedPromotionHistory");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__UserAcco__536C85E5104A8976");

            entity.ToTable("UserAccount");

            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.UserAccounts)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmployeeID_UserAccount");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PK__Vendor__FC8618D3BE8C4B42");

            entity.ToTable("Vendor");

            entity.Property(e => e.VendorId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("VendorID");
            entity.Property(e => e.BankAccountId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BankAccountID");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.VendorAddress).HasMaxLength(255);
            entity.Property(e => e.VendorName).HasMaxLength(50);

            entity.HasOne(d => d.BankAccount).WithMany(p => p.Vendors)
                .HasForeignKey(d => d.BankAccountId)
                .HasConstraintName("FK_BankAccountID_Vendor");
        });

        modelBuilder.Entity<WorkShift>(entity =>
        {
            entity.HasKey(e => e.WorkShiftId).HasName("PK__WorkShif__593DF98978370B16");

            entity.ToTable("WorkShift");

            entity.Property(e => e.WorkShiftId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("WorkShiftID");
            entity.Property(e => e.BaseSalary).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.SalaryCoefficient).HasColumnType("decimal(5, 1)");
            entity.Property(e => e.WorkShiftName)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<WorkShiftDistribution>(entity =>
        {
            entity.HasKey(e => new { e.PtemployeeId, e.WorkShiftId }).HasName("PK_Mutual_PTEmployeeID_WorkShiftID_WorkShiftDistribution");

            entity.ToTable("WorkShiftDistribution");

            entity.Property(e => e.PtemployeeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PTEmployeeID");
            entity.Property(e => e.WorkShiftId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("WorkShiftID");
            entity.Property(e => e.Absence).HasDefaultValue(false);

            entity.HasOne(d => d.Ptemployee).WithMany(p => p.WorkShiftDistributions)
                .HasForeignKey(d => d.PtemployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PTEmployeeID_WorkShiftDistribution");

            entity.HasOne(d => d.WorkShift).WithMany(p => p.WorkShiftDistributions)
                .HasForeignKey(d => d.WorkShiftId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkShiftID_WorkShiftDistribution");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
