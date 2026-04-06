using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tethkar.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEventCategoryRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EventCategories_CategoryId",
                table: "EventCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCategories_EventId",
                table: "EventCategories",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventCategories_Categories_CategoryId",
                table: "EventCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventCategories_Events_EventId",
                table: "EventCategories",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventCategories_Categories_CategoryId",
                table: "EventCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_EventCategories_Events_EventId",
                table: "EventCategories");

            migrationBuilder.DropIndex(
                name: "IX_EventCategories_CategoryId",
                table: "EventCategories");

            migrationBuilder.DropIndex(
                name: "IX_EventCategories_EventId",
                table: "EventCategories");
        }
    }
}
