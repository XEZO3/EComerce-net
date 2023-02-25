using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class productsaddavilibility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avilability",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avilability",
                table: "products");
        }
    }
}
