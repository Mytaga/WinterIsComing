using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinterIsComing.Infrastructure.Migrations
{
    public partial class SeedBulgarianResorts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfSlopes",
                table: "Resorts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "SkiAreaSizes",
                table: "Resorts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Resorts",
                columns: new[] { "Id", "CountryId", "Description", "Elevation", "ImageUrl", "Likes", "Name", "NumberOfSlopes", "SkiAreaSizes" },
                values: new object[,]
                {
                    { "239fb5bc-f32a-44ff-ad30-992feda18a41", "3e6773cb-dd81-4f92-91a6-05816ba80c07", "Malyovitsa is located in the Rila mountain. There are no lifts just rope tows. It's good for freeride.", "2000", "https://4vlast-bg.com/wp-content/uploads/2021/01/89911107_166885198185957_7272630966554722304_o.jpg", 0, "Malyovitsa", 2, 4.0 },
                    { "4b604930-85d7-44d5-9d4b-4844d1745742", "3e6773cb-dd81-4f92-91a6-05816ba80c07", "Pamporovo is located in the Rhodope mountain. It offers warm hospitality and is very suitable for beginners.", "1920", "https://www.igluski.com/images/_i60381238.jpg", 0, "Pamporovo", 20, 36.8 },
                    { "4b94a373-e809-4f52-90c2-af49ed73cb30", "3e6773cb-dd81-4f92-91a6-05816ba80c07", "Kartala is located close to Blagoevgrad in the Rila mountain. Not a lot of slopes but good for freeride.", "2350", "https://bg.nexustrace.com/wp-content/uploads/2020/11/kartala-2.jpg", 0, "Kartala", 2, 5.0 },
                    { "79e82d3d-7482-4ffe-8c1c-55a0e47798ec", "3e6773cb-dd81-4f92-91a6-05816ba80c07", "Bezbog is located in the Pirin mountain next to Bansko. There is only one slope but is a favourite site for freeride and backcountry.", "2240", "https://bulgariaview.com/view/albums/17/46.jpg", 0, "Bezbog", 1, 5.0 },
                    { "7f412e7c-3999-476e-8f5f-a7a14440ea4b", "3e6773cb-dd81-4f92-91a6-05816ba80c07", "Bansko is the biggest ski resort in Bulgaria located in the Pirin mountain. It hosts FIS World Cup alpine ski races.", "2600", "https://www.skibansko.bg/wp-content/uploads/2016/06/bansko-ski-runs.jpg", 0, "Bansko", 20, 75.0 },
                    { "bd83c318-a14f-4113-9408-0d71d19beb98", "3e6773cb-dd81-4f92-91a6-05816ba80c07", "Vitosha is located just 20km away from Sofia city center.Unfortunately most of the lifts are abandoned and few are working.", "2200", "https://www.skiresort.info/fileadmin/_processed_/29/94/4a/a0/ba07658242.jpg", 0, "Vitosha", 12, 8.0 },
                    { "be4598ef-38d2-4acb-bf23-8b859d4a2b21", "3e6773cb-dd81-4f92-91a6-05816ba80c07", "Borovets is the second biggest ski resort in Bulgaria located in the Rila mountain.It offers night skiing.", "2500", "https://www.skiborovets.bg/wp-content/uploads/2016/08/borovets-night-skiing.jpg", 0, "Borovets", 27, 58.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: "239fb5bc-f32a-44ff-ad30-992feda18a41");

            migrationBuilder.DeleteData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: "4b604930-85d7-44d5-9d4b-4844d1745742");

            migrationBuilder.DeleteData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: "4b94a373-e809-4f52-90c2-af49ed73cb30");

            migrationBuilder.DeleteData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: "79e82d3d-7482-4ffe-8c1c-55a0e47798ec");

            migrationBuilder.DeleteData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: "7f412e7c-3999-476e-8f5f-a7a14440ea4b");

            migrationBuilder.DeleteData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: "bd83c318-a14f-4113-9408-0d71d19beb98");

            migrationBuilder.DeleteData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: "be4598ef-38d2-4acb-bf23-8b859d4a2b21");

            migrationBuilder.DropColumn(
                name: "NumberOfSlopes",
                table: "Resorts");

            migrationBuilder.DropColumn(
                name: "SkiAreaSizes",
                table: "Resorts");
        }
    }
}
