using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spender.DAL.Migrations
{
    /// <inheritdoc />
    public partial class transactiontype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "transactionType",
                table: "Categories",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "transactionType",
                table: "Categories");
        }
    }
}
