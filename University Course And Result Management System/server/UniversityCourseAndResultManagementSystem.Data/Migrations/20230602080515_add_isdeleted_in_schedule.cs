using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityCourseAndResultManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class addisdeletedinschedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Schedules",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Schedules");
        }
    }
}
