using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Runtracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRunningRouteNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "RunningRoute",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "RunningRoute");
        }
    }
}
