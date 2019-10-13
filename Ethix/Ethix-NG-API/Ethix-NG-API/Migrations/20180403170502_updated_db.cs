using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EthixNGAPI.Migrations
{
    public partial class updated_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccounts_Currencies_CurrencyId",
                table: "CustomerAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerAccounts_CustomerAccountAccId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeRates_Currencies_currencyId",
                table: "ExchangeRates");

            migrationBuilder.DropIndex(
                name: "IX_ExchangeRates_currencyId",
                table: "ExchangeRates");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerAccountAccId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "currencyId",
                table: "ExchangeRates");

            migrationBuilder.DropColumn(
                name: "CustomerAccountAccId",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "ToCurrencyId",
                table: "ExchangeRates",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Operator",
                table: "ExchangeRates",
                type: "char(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FromCurrencyId",
                table: "ExchangeRates",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CustomerAccounts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyId",
                table: "CustomerAccounts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Class_Code",
                table: "CustomerAccounts",
                type: "char(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Acc_Type",
                table: "CustomerAccounts",
                type: "char(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ISO_Code",
                table: "Currencies",
                type: "char(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_FromCurrencyId",
                table: "ExchangeRates",
                column: "FromCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_ToCurrencyId",
                table: "ExchangeRates",
                column: "ToCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_CustomerId",
                table: "CustomerAccounts",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccounts_Currencies_CurrencyId",
                table: "CustomerAccounts",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "currencyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccounts_Customers_CustomerId",
                table: "CustomerAccounts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeRates_Currencies_FromCurrencyId",
                table: "ExchangeRates",
                column: "FromCurrencyId",
                principalTable: "Currencies",
                principalColumn: "currencyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeRates_Currencies_ToCurrencyId",
                table: "ExchangeRates",
                column: "ToCurrencyId",
                principalTable: "Currencies",
                principalColumn: "currencyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccounts_Currencies_CurrencyId",
                table: "CustomerAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccounts_Customers_CustomerId",
                table: "CustomerAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeRates_Currencies_FromCurrencyId",
                table: "ExchangeRates");

            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeRates_Currencies_ToCurrencyId",
                table: "ExchangeRates");

            migrationBuilder.DropIndex(
                name: "IX_ExchangeRates_FromCurrencyId",
                table: "ExchangeRates");

            migrationBuilder.DropIndex(
                name: "IX_ExchangeRates_ToCurrencyId",
                table: "ExchangeRates");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccounts_CustomerId",
                table: "CustomerAccounts");

            migrationBuilder.AlterColumn<int>(
                name: "ToCurrencyId",
                table: "ExchangeRates",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Operator",
                table: "ExchangeRates",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FromCurrencyId",
                table: "ExchangeRates",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "currencyId",
                table: "ExchangeRates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerAccountAccId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CustomerAccounts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyId",
                table: "CustomerAccounts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Class_Code",
                table: "CustomerAccounts",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Acc_Type",
                table: "CustomerAccounts",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ISO_Code",
                table: "Currencies",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_currencyId",
                table: "ExchangeRates",
                column: "currencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerAccountAccId",
                table: "Customers",
                column: "CustomerAccountAccId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccounts_Currencies_CurrencyId",
                table: "CustomerAccounts",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "currencyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerAccounts_CustomerAccountAccId",
                table: "Customers",
                column: "CustomerAccountAccId",
                principalTable: "CustomerAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeRates_Currencies_currencyId",
                table: "ExchangeRates",
                column: "currencyId",
                principalTable: "Currencies",
                principalColumn: "currencyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
