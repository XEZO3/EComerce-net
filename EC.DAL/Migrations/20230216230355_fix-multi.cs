using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class fixmulti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_products_BrandsId",
                table: "products",
                column: "BrandsId");

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                table: "products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_brands_BrandsId",
                table: "products",
                column: "BrandsId",
                principalTable: "brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_category_CategoryId",
                table: "products",
                column: "CategoryId",
                principalTable: "category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_brands_BrandsId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_category_CategoryId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_BrandsId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_CategoryId",
                table: "products");
        }
    }
}
