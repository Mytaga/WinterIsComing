using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinterIsComing.Infrastructure.Migrations
{
    public partial class SeedPrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "PassType", "ResortId", "Value" },
                values: new object[,]
                {
                    { "08050311-981e-4e03-8837-95c550c92a2e", 2, "be4598ef-38d2-4acb-bf23-8b859d4a2b21", 1500m },
                    { "09c02bc4-5ba9-43ee-b79f-dc18842c8e0b", 1, "be4598ef-38d2-4acb-bf23-8b859d4a2b21", 85m },
                    { "29f08d0a-bf1e-44ca-93af-ce05b2832275", 0, "239fb5bc-f32a-44ff-ad30-992feda18a41", 18m },
                    { "374705e6-309f-4ec0-9936-4c1cc15c527a", 1, "bd83c318-a14f-4113-9408-0d71d19beb98", 50m },
                    { "3d25295a-76b4-4a6e-ac2b-ccc75f50bbfd", 0, "bd83c318-a14f-4113-9408-0d71d19beb98", 40m },
                    { "59f29a21-69eb-47b2-ab5f-760050e3330d", 0, "7f412e7c-3999-476e-8f5f-a7a14440ea4b", 70m },
                    { "5e9370d6-fc61-4c39-b33b-1d83e85e40a1", 1, "4b604930-85d7-44d5-9d4b-4844d1745742", 85m },
                    { "626ce16f-e1e6-4e1b-bb43-08253a60717b", 1, "239fb5bc-f32a-44ff-ad30-992feda18a41", 25m },
                    { "827d687e-6ca8-417a-b16c-42b5a93f25c8", 1, "79e82d3d-7482-4ffe-8c1c-55a0e47798ec", 47m },
                    { "93b23e49-c762-47df-813f-046012736838", 0, "4b94a373-e809-4f52-90c2-af49ed73cb30", 45m },
                    { "9c587e25-5941-496c-aa6d-c2bc688a8877", 2, "7f412e7c-3999-476e-8f5f-a7a14440ea4b", 1700m },
                    { "b8816896-8c30-49b1-9173-a8c0cf70dd39", 0, "be4598ef-38d2-4acb-bf23-8b859d4a2b21", 70m },
                    { "baf8f5d8-583d-4815-af0b-a0027b2e46f5", 2, "bd83c318-a14f-4113-9408-0d71d19beb98", 650m },
                    { "c799e62e-50f3-441f-8c4a-26fae8db5339", 0, "4b604930-85d7-44d5-9d4b-4844d1745742", 63m },
                    { "d2477f38-8927-4c5e-a875-1e617d167871", 1, "7f412e7c-3999-476e-8f5f-a7a14440ea4b", 90m },
                    { "dd8ca596-0912-4a6e-8479-8d966962a23e", 1, "4b94a373-e809-4f52-90c2-af49ed73cb30", 60m },
                    { "ebc0e4f5-8eaf-45a1-8797-85220f027593", 2, "4b604930-85d7-44d5-9d4b-4844d1745742", 1530m }
                });

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: "4b94a373-e809-4f52-90c2-af49ed73cb30",
                column: "ImageUrl",
                value: "https://bg.nexustrace.com/wp-content/uploads/2020/11/kartala-2.jpg");

            migrationBuilder.InsertData(
                table: "Resorts",
                columns: new[] { "Id", "CountryId", "Description", "Elevation", "ImageUrl", "Likes", "Name", "NumberOfSlopes", "SkiAreaSizes" },
                values: new object[] { "2d5a0fa8-fcb9-46d7-8f19-01f5fb543116", "3e6773cb-dd81-4f92-91a6-05816ba80c07", "Rila Lakes is located in the Rila mountain. There is one slow lift and one rope tows. It's good for freeride and backcountry.", "2300", "https://www.360mag.bg/wp-content/uploads/2016/12/bg-kurorti-rilski-ezera.jpg", 0, "Rila Lakes", 2, 3.0 });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "PassType", "ResortId", "Value" },
                values: new object[] { "515cd33d-742a-40b3-a664-b5a1136c988a", 1, "2d5a0fa8-fcb9-46d7-8f19-01f5fb543116", 40m });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "PassType", "ResortId", "Value" },
                values: new object[] { "bbda776e-f33a-43a0-9b58-9657785b39f2", 0, "2d5a0fa8-fcb9-46d7-8f19-01f5fb543116", 30m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: "08050311-981e-4e03-8837-95c550c92a2e");

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: "09c02bc4-5ba9-43ee-b79f-dc18842c8e0b");

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: "29f08d0a-bf1e-44ca-93af-ce05b2832275");

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: "374705e6-309f-4ec0-9936-4c1cc15c527a");

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: "3d25295a-76b4-4a6e-ac2b-ccc75f50bbfd");

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: "515cd33d-742a-40b3-a664-b5a1136c988a");

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: "59f29a21-69eb-47b2-ab5f-760050e3330d");

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: "5e9370d6-fc61-4c39-b33b-1d83e85e40a1");

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: "626ce16f-e1e6-4e1b-bb43-08253a60717b");

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: "827d687e-6ca8-417a-b16c-42b5a93f25c8");

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: "93b23e49-c762-47df-813f-046012736838");

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: "9c587e25-5941-496c-aa6d-c2bc688a8877");

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: "b8816896-8c30-49b1-9173-a8c0cf70dd39");

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: "baf8f5d8-583d-4815-af0b-a0027b2e46f5");

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: "bbda776e-f33a-43a0-9b58-9657785b39f2");

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: "c799e62e-50f3-441f-8c4a-26fae8db5339");

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: "d2477f38-8927-4c5e-a875-1e617d167871");

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: "dd8ca596-0912-4a6e-8479-8d966962a23e");

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: "ebc0e4f5-8eaf-45a1-8797-85220f027593");

            migrationBuilder.DeleteData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: "2d5a0fa8-fcb9-46d7-8f19-01f5fb543116");

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: "4b94a373-e809-4f52-90c2-af49ed73cb30",
                column: "ImageUrl",
                value: "https://cf.bstatic.com/xdata/images/hotel/max1024x768/264298818.jpg?k=4440ca22573b7d33266f7fe7f6f73e764a206d4c05019de0fcf3355718265ea5&o=&hp=1");
        }
    }
}
