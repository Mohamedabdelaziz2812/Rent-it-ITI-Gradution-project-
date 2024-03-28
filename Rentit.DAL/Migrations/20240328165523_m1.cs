using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rentit.DAL.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributesPropertyy_Attributes_AttributesId",
                table: "AttributesPropertyy");

            migrationBuilder.RenameColumn(
                name: "AttributesId",
                table: "AttributesPropertyy",
                newName: "Attributes_propertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributesPropertyy_Attributes_Attributes_propertyId",
                table: "AttributesPropertyy",
                column: "Attributes_propertyId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributesPropertyy_Attributes_Attributes_propertyId",
                table: "AttributesPropertyy");

            migrationBuilder.RenameColumn(
                name: "Attributes_propertyId",
                table: "AttributesPropertyy",
                newName: "AttributesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributesPropertyy_Attributes_AttributesId",
                table: "AttributesPropertyy",
                column: "AttributesId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
