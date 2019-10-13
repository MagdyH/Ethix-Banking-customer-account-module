using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EthixNGAPI.Migrations
{
    public partial class updated_branch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "branchId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Class_Code",
                table: "CustomerAccounts",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Acc_Number",
                table: "CustomerAccounts",
                type: "varchar(50)",
                maxLength: 12,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    BranchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.BranchId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_branchId",
                table: "Customers",
                column: "branchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Branch_branchId",
                table: "Customers",
                column: "branchId",
                principalTable: "Branch",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Branch_branchId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropIndex(
                name: "IX_Customers_branchId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "branchId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Acc_Number",
                table: "CustomerAccounts");

            migrationBuilder.AlterColumn<string>(
                name: "Class_Code",
                table: "CustomerAccounts",
                type: "char(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
