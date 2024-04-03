using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rentit.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "Img_URL",
                value: "D:\\iti\\rentit-project\\Rentit.APIs\\Assets\\PropertiesImages\\tataalexlolo2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "Img_URL",
                value: "https://img.freepik.com/free-vector/hand-sketch-art-decor-inspired-large-floral-arrangement_1409-4511.jpg?w=740&t=st=1711924304~exp=1711924904~hmac=198bbde6e9b3da518d3fe0904717c37d2bb559fb797e03b42663c1e061e9722f");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "Img_URL",
                value: "tataalexlolo1.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "Img_URL",
                value: "image3.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "Img_URL",
                value: "image4.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "Img_URL",
                value: "image5.jpg");
        }
    }
}
