using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    public partial class insertrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_libraryCenter_LibraryCenterId",
                table: "book");

            migrationBuilder.DropIndex(
                name: "IX_book_LibraryCenterId",
                table: "book");

            migrationBuilder.DropColumn(
                name: "LibraryCenterId",
                table: "book");

            migrationBuilder.AddColumn<int>(
                name: "LibraryId",
                table: "book",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_book_CustomerId",
                table: "book",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_book_LibraryId",
                table: "book",
                column: "LibraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_book_customer_CustomerId",
                table: "book",
                column: "CustomerId",
                principalTable: "customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_book_libraryCenter_LibraryId",
                table: "book",
                column: "LibraryId",
                principalTable: "libraryCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_customer_CustomerId",
                table: "book");

            migrationBuilder.DropForeignKey(
                name: "FK_book_libraryCenter_LibraryId",
                table: "book");

            migrationBuilder.DropIndex(
                name: "IX_book_CustomerId",
                table: "book");

            migrationBuilder.DropIndex(
                name: "IX_book_LibraryId",
                table: "book");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                table: "book");

            migrationBuilder.AddColumn<int>(
                name: "LibraryCenterId",
                table: "book",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_book_LibraryCenterId",
                table: "book",
                column: "LibraryCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_book_libraryCenter_LibraryCenterId",
                table: "book",
                column: "LibraryCenterId",
                principalTable: "libraryCenter",
                principalColumn: "Id");
        }
    }
}
