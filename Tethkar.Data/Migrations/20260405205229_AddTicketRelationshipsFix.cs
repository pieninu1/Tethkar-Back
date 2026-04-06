using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tethkar.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTicketRelationshipsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BuyerUserId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "OrderItemId",
                table: "Tickets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TicketTypeId",
                table: "Tickets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BuyerUserId",
                table: "Tickets",
                column: "BuyerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OrderItemId",
                table: "Tickets",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketTypeId",
                table: "Tickets",
                column: "TicketTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_OrderItems_OrderItemId",
                table: "Tickets",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketTypes_TicketTypeId",
                table: "Tickets",
                column: "TicketTypeId",
                principalTable: "TicketTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_BuyerUserId",
                table: "Tickets",
                column: "BuyerUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_OrderItems_OrderItemId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketTypes_TicketTypeId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_BuyerUserId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_BuyerUserId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_OrderItemId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketTypeId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "BuyerUserId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketTypeId",
                table: "Tickets");
        }
    }
}
