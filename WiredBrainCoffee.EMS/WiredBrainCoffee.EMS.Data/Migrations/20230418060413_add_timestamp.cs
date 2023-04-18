using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WiredBrainCoffee.EMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_timestamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "Employees",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Employees");
        }
    }
}
