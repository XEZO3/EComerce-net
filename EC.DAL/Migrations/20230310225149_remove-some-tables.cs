using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class removesometables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderStates");

            migrationBuilder.DropTable(
                name: "productState");

            migrationBuilder.DropIndex(
                name: "IX_customers_UsersId",
                table: "customers");

            migrationBuilder.AlterColumn<string>(
                name: "OrderStatus",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_customers_UsersId",
                table: "customers",
                column: "UsersId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_customers_UsersId",
                table: "customers");

            migrationBuilder.AlterColumn<int>(
                name: "OrderStatus",
                table: "orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "orderStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productState", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customers_UsersId",
                table: "customers",
                column: "UsersId");
        }
    }
}
