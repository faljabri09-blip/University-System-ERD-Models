using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_system.Migrations
{
    /// <inheritdoc />
    public partial class editInstructorSalary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "salary",
                table: "instructors",
                newName: "InstructorSalary");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InstructorSalary",
                table: "instructors",
                newName: "salary");
        }
    }
}
