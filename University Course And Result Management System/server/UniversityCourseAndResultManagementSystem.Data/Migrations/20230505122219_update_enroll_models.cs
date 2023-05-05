using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityCourseAndResultManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateenrollmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "EnrolledCourses");

            migrationBuilder.AddColumn<DateTime>(
                name: "Grade",
                table: "StudentEnrolledCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "StudentEnrolledCourses");

            migrationBuilder.AddColumn<DateTime>(
                name: "Grade",
                table: "EnrolledCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
