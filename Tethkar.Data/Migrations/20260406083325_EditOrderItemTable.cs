using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tethkar.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditOrderItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_TicketTypes_TicketTypeId",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "TicketTypeId",
                table: "OrderItems",
                newName: "TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_TicketTypeId",
                table: "OrderItems",
                newName: "IX_OrderItems_TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Tickets_TicketId",
                table: "OrderItems",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Tickets_TicketId",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "OrderItems",
                newName: "TicketTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_TicketId",
                table: "OrderItems",
                newName: "IX_OrderItems_TicketTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_TicketTypes_TicketTypeId",
                table: "OrderItems",
                column: "TicketTypeId",
                principalTable: "TicketTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
