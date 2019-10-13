using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EthixNGAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    currencyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ISO_Code = table.Column<string>(maxLength: 3, nullable: true),
                    currency = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.currencyId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAccounts",
                columns: table => new
                {
                    AccId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Acc_Type = table.Column<string>(maxLength: 2, nullable: true),
                    Class_Code = table.Column<string>(maxLength: 3, nullable: true),
                    CurrencyId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    Openning_Bal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAccounts", x => x.AccId);
                    table.ForeignKey(
                        name: "FK_CustomerAccounts_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "currencyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(nullable: false),
                    FromCurrencyId = table.Column<int>(nullable: false),
                    Operator = table.Column<string>(maxLength: 1, nullable: true),
                    ToCurrencyId = table.Column<int>(nullable: false),
                    currencyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangeRates_Currencies_currencyId",
                        column: x => x.currencyId,
                        principalTable: "Currencies",
                        principalColumn: "currencyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustmerName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CustomerAccountAccId = table.Column<int>(nullable: true),
                    OpenDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerAccounts_CustomerAccountAccId",
                        column: x => x.CustomerAccountAccId,
                        principalTable: "CustomerAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_CurrencyId",
                table: "CustomerAccounts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerAccountAccId",
                table: "Customers",
                column: "CustomerAccountAccId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_currencyId",
                table: "ExchangeRates",
                column: "currencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ExchangeRates");

            migrationBuilder.DropTable(
                name: "CustomerAccounts");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
