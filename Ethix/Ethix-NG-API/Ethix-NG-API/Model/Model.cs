using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ethix_NG_API.Model
{
    public class Ethix_NGContext : DbContext
    {
        public Ethix_NGContext(DbContextOptions<Ethix_NGContext> options)
            : base(options)
        { }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public DbSet<ClassCode> ClassCodes { get; set; }
    }

    public class Currency
    {
        [Key]
        public int currencyId { get; set; }
        [StringLength(10), Column(TypeName = "varchar(10)")]
        public string currency { get; set; }
        [StringLength(3),MaxLength(3), Column(TypeName = "char(3)")]
        public string ISO_Code { get; set; }
        [MaxLength(9),MinLength(2)]
        public int decimal_Digits { get; set; }
    }

    public class ExchangeRate
    {
        [Key]
        public int Id { get; set; }
        [StringLength(1), MaxLength(1), Column(TypeName = "char(1)")]
        public string Operator { get; set; }
        //[RegularExpression(@"^\d+\.\d{0,2}$")]
        //[Range(0, 9999999999999999999.999999)]
        [Column(TypeName = "decimal(21,6)")]
        public decimal Amount { get; set; }
        [ForeignKey("FromCurrencyId")]
        public Currency FromCurrency { get; set; }
        [ForeignKey("ToCurrencyId")]
        public Currency ToCurrency { get; set; }
    }

    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string CustmerName { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true), Column(TypeName = "date")]
        public DateTime OpenDate { get; set; }
        [ForeignKey("branchId")]
        public virtual Branch Branch { get; set; }
    }

    public class CustomerAccount
    {
        [Key]
        public int AccId { get; set; }
        [StringLength(2),MaxLength(2), Column(TypeName = "char(2)")]
        public string Acc_Type { get; set; }
        [StringLength(12), MaxLength(12), Column(TypeName = "varchar(50)")]
        public string Acc_Number { get; set; }
        public string Class_Code { get; set; }
        //[RegularExpression(@"^\d+\.\d{0,2}$")]
        //[Range(0, 9999999999999999999.999999)]
        [Column(TypeName = "decimal(21,6)")]
        public decimal Openning_Bal { get; set; }
        public bool IsClosed { get; set; }
        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }

    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        [StringLength(100), Column(TypeName = "varchar(100)")]
        public string BranchName { get; set; }

    }
    public class ClassCode
    {
        [Key]
        public int ClassCodeId { get; set; }
        [StringLength(3), MaxLength(3), Column(TypeName = "char(3)")]
        public string Class_Code { get; set; }
        [StringLength(2), MaxLength(2), Column(TypeName = "char(2)")]
        public string Acc_Type { get; set; }

    }
}