using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class loaned : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanedBooks_Books_BookId1",
                table: "LoanedBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanedBooks",
                table: "LoanedBooks");

            migrationBuilder.DropIndex(
                name: "IX_LoanedBooks_BookId1",
                table: "LoanedBooks");

            migrationBuilder.RenameColumn(
                name: "BookId1",
                table: "LoanedBooks",
                newName: "IdBook");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanedBooks",
                table: "LoanedBooks",
                column: "IdIdBook");

            migrationBuilder.CreateIndex(
                name: "IX_LoanedBooks_BookId",
                table: "LoanedBooks",
                column: "BookId");

         
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanedBooks_Books_BookId",
                table: "LoanedBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanedBooks",
                table: "LoanedBooks");

            migrationBuilder.DropIndex(
                name: "IX_LoanedBooks_BookId",
                table: "LoanedBooks");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LoanedBooks",
                newName: "BookId1");

            

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanedBooks",
                table: "LoanedBooks",
                column: "BookId");

        }
    }
}
