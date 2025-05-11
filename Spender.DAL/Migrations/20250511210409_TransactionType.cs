using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spender.DAL.Migrations
{
    /// <inheritdoc />
    public partial class TransactionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "transactionType",
                table: "Categories",
                newName: "TransactionType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionType",
                table: "Categories",
                newName: "transactionType");
        }
    }
}
