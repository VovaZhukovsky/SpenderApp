using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spender.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MailUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Clients_Mail",
                table: "Clients",
                column: "Mail",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clients_Mail",
                table: "Clients");
        }
    }
}
