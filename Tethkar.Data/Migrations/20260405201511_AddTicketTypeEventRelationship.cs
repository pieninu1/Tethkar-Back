using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tethkar.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTicketTypeEventRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EventId",
                table: "TicketTypes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_TicketTypes_EventId",
                table: "TicketTypes",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTypes_Events_EventId",
                table: "TicketTypes",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketTypes_Events_EventId",
                table: "TicketTypes");

            migrationBuilder.DropIndex(
                name: "IX_TicketTypes_EventId",
                table: "TicketTypes");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "TicketTypes");
        }
    }
}
