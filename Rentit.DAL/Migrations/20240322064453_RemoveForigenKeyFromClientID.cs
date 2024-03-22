using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rentit.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveForigenKeyFromClientID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Users_ClientiD",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClientiD",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClientiD",
                table: "AspNetUsers",
                column: "ClientiD");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Users_ClientiD",
                table: "AspNetUsers",
                column: "ClientiD",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
