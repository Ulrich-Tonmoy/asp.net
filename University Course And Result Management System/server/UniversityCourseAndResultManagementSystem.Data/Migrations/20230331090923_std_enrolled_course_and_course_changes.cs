using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityCourseAndResultManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class stdenrolledcourseandcoursechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "EnrolledCourses");

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "StudentEnrolledCourses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StudentEnrolledCourses",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "StudentEnrolledCourses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StudentEnrolledCourses");

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "EnrolledCourses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
