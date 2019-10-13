﻿// <auto-generated />
using Ethix_NG_API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EthixNGAPI.Migrations
{
    [DbContext(typeof(Ethix_NGContext))]
    [Migration("20180404065437_update-classcode")]
    partial class updateclasscode
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ethix_NG_API.Model.Branch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BranchName")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("BranchId");

                    b.ToTable("Branch");
                });

            modelBuilder.Entity("Ethix_NG_API.Model.Currency", b =>
                {
                    b.Property<int>("currencyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ISO_Code")
                        .HasColumnType("char(3)")
                        .HasMaxLength(3);

                    b.Property<string>("currency")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("currencyId");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("Ethix_NG_API.Model.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustmerName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("OpenDate");

                    b.Property<int?>("branchId");

                    b.HasKey("CustomerId");

                    b.HasIndex("branchId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Ethix_NG_API.Model.CustomerAccount", b =>
                {
                    b.Property<int>("AccId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Acc_Number")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(12);

                    b.Property<string>("Acc_Type")
                        .HasColumnType("char(2)")
                        .HasMaxLength(2);

                    b.Property<string>("Class_Code");

                    b.Property<int?>("CurrencyId");

                    b.Property<int?>("CustomerId");

                    b.Property<bool>("IsClosed");

                    b.Property<decimal>("Openning_Bal")
                        .HasColumnType("decimal(21,6)");

                    b.HasKey("AccId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerAccounts");
                });

            modelBuilder.Entity("Ethix_NG_API.Model.ExchangeRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(21,6)");

                    b.Property<int?>("FromCurrencyId");

                    b.Property<string>("Operator")
                        .HasColumnType("char(1)")
                        .HasMaxLength(1);

                    b.Property<int?>("ToCurrencyId");

                    b.HasKey("Id");

                    b.HasIndex("FromCurrencyId");

                    b.HasIndex("ToCurrencyId");

                    b.ToTable("ExchangeRates");
                });

            modelBuilder.Entity("Ethix_NG_API.Model.Customer", b =>
                {
                    b.HasOne("Ethix_NG_API.Model.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("branchId");
                });

            modelBuilder.Entity("Ethix_NG_API.Model.CustomerAccount", b =>
                {
                    b.HasOne("Ethix_NG_API.Model.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");

                    b.HasOne("Ethix_NG_API.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Ethix_NG_API.Model.ExchangeRate", b =>
                {
                    b.HasOne("Ethix_NG_API.Model.Currency", "FromCurrency")
                        .WithMany()
                        .HasForeignKey("FromCurrencyId");

                    b.HasOne("Ethix_NG_API.Model.Currency", "ToCurrency")
                        .WithMany()
                        .HasForeignKey("ToCurrencyId");
                });
#pragma warning restore 612, 618
        }
    }
}
