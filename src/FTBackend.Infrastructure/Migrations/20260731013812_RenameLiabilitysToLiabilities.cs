using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FTBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameLiabilitysToLiabilities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Liabilitys",
                table: "Liabilitys");

            migrationBuilder.RenameTable(
                name: "Liabilitys",
                newName: "Liabilities");

            migrationBuilder.RenameIndex(
                name: "IX_Liabilitys_UserId",
                table: "Liabilities",
                newName: "IX_Liabilities_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Liabilities",
                table: "Liabilities",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Liabilities",
                table: "Liabilities");

            migrationBuilder.RenameTable(
                name: "Liabilities",
                newName: "Liabilitys");

            migrationBuilder.RenameIndex(
                name: "IX_Liabilities_UserId",
                table: "Liabilitys",
                newName: "IX_Liabilitys_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Liabilitys",
                table: "Liabilitys",
                column: "Id");
        }
    }
}
