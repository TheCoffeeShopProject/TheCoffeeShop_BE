using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheCoffeeCatBusinessObject.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Subscription_SubscriptionID",
                table: "OrderDetail");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubscriptionID",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Subscription_SubscriptionID",
                table: "OrderDetail",
                column: "SubscriptionID",
                principalTable: "Subscription",
                principalColumn: "SubscriptionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Subscription_SubscriptionID",
                table: "OrderDetail");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubscriptionID",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Subscription_SubscriptionID",
                table: "OrderDetail",
                column: "SubscriptionID",
                principalTable: "Subscription",
                principalColumn: "SubscriptionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
