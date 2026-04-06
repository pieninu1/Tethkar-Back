using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tethkar.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderBuyerRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BuyerUserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuyerUserId",
                table: "Orders",
                column: "BuyerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_BuyerUserId",
                table: "Orders",
                column: "BuyerUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_BuyerUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BuyerUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BuyerUserId",
                table: "Orders");
        }
    }
}
