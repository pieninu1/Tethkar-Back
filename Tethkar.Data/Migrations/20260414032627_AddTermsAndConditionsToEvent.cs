using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tethkar.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTermsAndConditionsToEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TermsAndConditions",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TermsAndConditions",
                table: "Events");
        }
    }
}
