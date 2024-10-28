using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booc.Migrations
{
    /// <inheritdoc />
    public partial class Warehouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookstoreId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_warehouses_bookstore_BookstoreId",
                        column: x => x.BookstoreId,
                        principalTable: "bookstore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_warehouses_BookstoreId",
                table: "warehouses",
                column: "BookstoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "warehouses");
        }
    }
}
