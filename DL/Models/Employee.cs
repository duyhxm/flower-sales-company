using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Employee
{
    public string EmployeeId { get; set; } = null!;

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public string? FirstName { get; set; }

    public DateOnly? Birthday { get; set; }

    public string? Gender { get; set; }

    public string? EmployeeAddress { get; set; }

    public string? CitizenId { get; set; }

    public string? Email { get; set; }

    public string? TaxId { get; set; }

    public string? WorkType { get; set; }

    public string? PhoneNumber { get; set; }

    public string? BankAccountId { get; set; }

    public virtual BankAccount? BankAccount { get; set; }

    public virtual ICollection<EmployeeAllowance> EmployeeAllowances { get; set; } = new List<EmployeeAllowance>();

    public virtual ICollection<EmployeeBonu> EmployeeBonus { get; set; } = new List<EmployeeBonu>();

    public virtual ICollection<EmployeeJobTitle> EmployeeJobTitles { get; set; } = new List<EmployeeJobTitle>();

    public virtual ICollection<EmployeePayrollHistory> EmployeePayrollHistories { get; set; } = new List<EmployeePayrollHistory>();

    public virtual Ftemployee? Ftemployee { get; set; }

    public virtual ICollection<ProductCreationHistory> ProductCreationHistories { get; set; } = new List<ProductCreationHistory>();

    public virtual Ptemployee? Ptemployee { get; set; }

    public virtual ICollection<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
}
