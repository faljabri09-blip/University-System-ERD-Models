using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce_system.Migrations
{
    /// <inheritdoc />
    public partial class editProductPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "ProductPrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductPrice",
                table: "Products",
                newName: "price");
        }
    }
}
