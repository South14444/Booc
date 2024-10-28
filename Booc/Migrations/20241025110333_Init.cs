using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booc.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trilogies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trilogies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bookstore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameBook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    authorId = table.Column<int>(type: "int", nullable: false),
                    publishersId = table.Column<int>(type: "int", nullable: false),
                    Number_of_pages = table.Column<int>(type: "int", nullable: false),
                    genreId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost_price = table.Column<int>(type: "int", nullable: false),
                    Price_for_sale = table.Column<int>(type: "int", nullable: false),
                    TrilogiesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookstore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookstore_authors_authorId",
                        column: x => x.authorId,
                        principalTable: "authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookstore_genres_genreId",
                        column: x => x.genreId,
                        principalTable: "genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookstore_publishers_publishersId",
                        column: x => x.publishersId,
                        principalTable: "publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookstore_trilogies_TrilogiesId",
                        column: x => x.TrilogiesId,
                        principalTable: "trilogies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookstore_authorId",
                table: "bookstore",
                column: "authorId");

            migrationBuilder.CreateIndex(
                name: "IX_bookstore_genreId",
                table: "bookstore",
                column: "genreId");

            migrationBuilder.CreateIndex(
                name: "IX_bookstore_publishersId",
                table: "bookstore",
                column: "publishersId");

            migrationBuilder.CreateIndex(
                name: "IX_bookstore_TrilogiesId",
                table: "bookstore",
                column: "TrilogiesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "bookstore");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "publishers");

            migrationBuilder.DropTable(
                name: "trilogies");
        }
    }
}
