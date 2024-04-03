using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rentit.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Gallery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "Img_URL",
                value: "https://img.freepik.com/free-photo/3d-house-model-with-modern-architecture_23-2151004065.jpg?t=st=1712117397~exp=1712120997~hmac=1a2ad4c7342725d276b70bee4e75dd551f744052cac67a255d150de79fc61745&w=900");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "Img_URL",
                value: "https://img.freepik.com/free-photo/front-view-front-door-with-white-wall-plants_23-2149360608.jpg?t=st=1712117418~exp=1712121018~hmac=61d37274b4944fec15d6f5ed1eb4f004e4772dd03248df0c058e3e2f651c1f9a&w=740");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Img_URL", "Img_order" },
                values: new object[] { "https://img.freepik.com/free-photo/mosque-pictures-moroccan-wall-pattern_1203-5080.jpg?t=st=1712117254~exp=1712120854~hmac=3f3d33979735c2b8d03323cf139d35d7cc2c2919c8eaa1c2b1272923e1a1c142&w=740", 2 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "Img_order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "Img_URL",
                value: "https://img.freepik.com/free-photo/luxury-pool-villa-spectacular-contemporary-design-digital-art-real-estate-home-house-property-ge_1258-150749.jpg?t=st=1712117445~exp=1712121045~hmac=429a6408e64495a6d543152f5243d1d29d2d7651937d7c7c34802828d94a8a9e&w=900");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "Img_URL",
                value: "https://img.freepik.com/free-photo/road-city_1417-1426.jpg?t=st=1712117465~exp=1712121065~hmac=303d36a852079b1948e617f509dfce9423bc4ba52da3d484dadb5dacbe7225d4&w=900");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                column: "Img_URL",
                value: "https://img.freepik.com/free-photo/3d-rendering-house-model_23-2150799723.jpg?t=st=1712117482~exp=1712121082~hmac=8291103bc5178bba4099f63c14a648b345ef908c1a66bd2914378f534b777fca&w=740");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8,
                column: "Img_URL",
                value: "https://img.freepik.com/free-photo/3d-rendering-house-model_23-2150799687.jpg?t=st=1712117500~exp=1712121100~hmac=7584209dfe4ab0fa004cb16a25bf17619bd9fdc0cfad245928ac6b199fd82cc0&w=740");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9,
                column: "Img_URL",
                value: "https://img.freepik.com/free-photo/3d-rendering-house-model_23-2150799725.jpg?t=st=1712117522~exp=1712121122~hmac=2d8432ff5656294aff471f60925a6724959e51b3ff96e594afa6827b8916cbc8&w=740");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10,
                column: "Img_URL",
                value: "https://img.freepik.com/free-photo/abandoned-closed-wooden-church-forest-countryside_181624-798.jpg?t=st=1712117536~exp=1712121136~hmac=f022c3c067bc808c2fa623e2fdb1accb008d7d2c0859d66a3dbe1a347701fe41&w=740");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11,
                column: "Img_URL",
                value: "https://img.freepik.com/free-photo/3d-rendering-house-model_23-2150799703.jpg?t=st=1712117559~exp=1712121159~hmac=614b9fba699ee26e9ba722f3e905473c349c80fa686151ebd3a11b181b7406a3&w=360");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12,
                column: "Img_URL",
                value: "https://img.freepik.com/free-photo/vertical-shot-modern-apartments-daytime_181624-13625.jpg?t=st=1712117582~exp=1712121182~hmac=7f04d601a4ffdb3a9fed51e6e517752e4cbc903506b422a15c8146e9cea14d5e&w=740");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13,
                column: "Img_URL",
                value: "https://img.freepik.com/free-photo/promenade-canal-dubai-marina-with-luxury-skyscrapers-around-united-arab-emirates_231208-7556.jpg?t=st=1712117605~exp=1712121205~hmac=83fec7ef9d2360d0ab2e3354604fadbcf83d9fea4073a0fd81f4429988fe7a85&w=740");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 14,
                column: "Img_URL",
                value: "https://img.freepik.com/free-photo/analog-landscape-city-with-buildings_23-2149661457.jpg?t=st=1712117640~exp=1712121240~hmac=d5bafc7058c817487e4cc8aef8bc218d30547889a3b7253402b253c13c44d04c&w=740");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 15,
                column: "Img_URL",
                value: "https://img.freepik.com/free-photo/3d-house-model-with-modern-architecture_23-2151004054.jpg?t=st=1712117688~exp=1712121288~hmac=0a0c307151447c7303579f8a6442870ec814f6ecd1e6c5638638a58cf823c982&w=900");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 16,
                column: "Img_URL",
                value: "https://img.freepik.com/free-photo/contemporary-house-interior-design_23-2151050939.jpg?t=st=1712117704~exp=1712121304~hmac=e0f42042c3020b895162605ec418bba3b509993be192a4b1062ecad1900a5b1f&w=900");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "Img_URL",
                value: "image1.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "Img_URL",
                value: "image2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Img_URL", "Img_order" },
                values: new object[] { "D:\\iti\\rentit-project\\Rentit.APIs\\Assets\\PropertiesImages\\tataalexlolo2.jpg", 3 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "Img_order",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "Img_URL",
                value: "tataalexlolo1.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "Img_URL",
                value: "image6.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                column: "Img_URL",
                value: "image7.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8,
                column: "Img_URL",
                value: "image8.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9,
                column: "Img_URL",
                value: "image9.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10,
                column: "Img_URL",
                value: "image10.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11,
                column: "Img_URL",
                value: "image11.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12,
                column: "Img_URL",
                value: "image12.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13,
                column: "Img_URL",
                value: "image13.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 14,
                column: "Img_URL",
                value: "image14.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 15,
                column: "Img_URL",
                value: "image15.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 16,
                column: "Img_URL",
                value: "image16.jpg");
        }
    }
}
