using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityCourseAndResultManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class isDeleteaddedtostudentEnrolledCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StudentEnrolledCourses",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
