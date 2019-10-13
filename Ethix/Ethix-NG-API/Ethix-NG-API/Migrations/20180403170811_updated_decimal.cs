using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EthixNGAPI.Migrations
{
    public partial class updated_decimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ExchangeRates",
                type: "decimal(21,6)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Openning_Bal",
                table: "CustomerAccounts",
                type: "decimal(21,6)",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ExchangeRates",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(21,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Openning_Bal",
                table: "CustomerAccounts",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(21,6)");
        }
    }
}
