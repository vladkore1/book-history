using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHistory.Migrations
{
    /// <inheritdoc />
    public partial class AddBookChangeIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookChanges_BookId",
                table: "BookChanges");

            migrationBuilder.CreateIndex(
                name: "IX_BookChanges_BookId_OccurredAt",
                table: "BookChanges",
                columns: new[] { "BookId", "OccurredAt" });

            migrationBuilder.CreateIndex(
                name: "IX_BookChanges_OccurredAt",
                table: "BookChanges",
                column: "OccurredAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookChanges_BookId_OccurredAt",
                table: "BookChanges");

            migrationBuilder.DropIndex(
                name: "IX_BookChanges_OccurredAt",
                table: "BookChanges");

            migrationBuilder.CreateIndex(
                name: "IX_BookChanges_BookId",
                table: "BookChanges",
                column: "BookId");
        }
    }
}
