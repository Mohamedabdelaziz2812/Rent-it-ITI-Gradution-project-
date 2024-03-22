using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rentit.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUseridToClientId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Users_UseriD",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UseriD",
                table: "AspNetUsers",
                newName: "ClientiD");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_UseriD",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_ClientiD");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Users_ClientiD",
                table: "AspNetUsers",
                column: "ClientiD",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Users_ClientiD",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ClientiD",
                table: "AspNetUsers",
                newName: "UseriD");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_ClientiD",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_UseriD");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Users_UseriD",
                table: "AspNetUsers",
                column: "UseriD",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
