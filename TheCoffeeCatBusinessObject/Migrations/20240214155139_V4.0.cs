using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheCoffeeCatBusinessObject.Migrations
{
    public partial class V40 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Subscription",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "SubscriptionID",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_SubscriptionID",
                table: "OrderDetail",
                column: "SubscriptionID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Subscription_SubscriptionID",
                table: "OrderDetail",
                column: "SubscriptionID",
                principalTable: "Subscription",
                principalColumn: "SubscriptionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Subscription_SubscriptionID",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_SubscriptionID",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "SubscriptionID",
                table: "OrderDetail");
        }
    }
}
