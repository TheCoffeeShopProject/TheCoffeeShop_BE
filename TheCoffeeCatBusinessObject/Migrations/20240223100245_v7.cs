using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheCoffeeCatBusinessObject.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerID",
                table: "Order",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CPID",
                table: "Order",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StaffID",
                table: "Order",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Order_CPID",
                table: "Order",
                column: "CPID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StaffID",
                table: "Order",
                column: "StaffID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_CustomerPackage_CPID",
                table: "Order",
                column: "CPID",
                principalTable: "CustomerPackage",
                principalColumn: "CPID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Staff_StaffID",
                table: "Order",
                column: "StaffID",
                principalTable: "Staff",
                principalColumn: "StaffID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_CustomerPackage_CPID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Staff_StaffID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_CPID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_StaffID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CPID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "StaffID",
                table: "Order");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerID",
                table: "Order",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
