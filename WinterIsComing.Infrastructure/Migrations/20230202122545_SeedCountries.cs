using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinterIsComing.Infrastructure.Migrations
{
    public partial class SeedCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "2e2bfac9-4671-4b3f-8684-100b21e60b30", "Greece" },
                    { "37c00aa0-b7de-4df2-9277-da14ab91d122", "Andora" },
                    { "3e6773cb-dd81-4f92-91a6-05816ba80c07", "Bulgaria" },
                    { "526ac75f-18c7-47c0-bc3c-733074a607e2", "France" },
                    { "6f511291-50cf-4bb1-bd29-9c1dc627bf76", "Austria" },
                    { "7734eba6-bbd6-413b-aa0d-4e990edb57a3", "Romania" },
                    { "d3312ea7-f12a-4e69-97a4-8a05c951626c", "Serbia" },
                    { "f332fd70-5e14-4973-b46f-c769912ddc03", "Italy" },
                    { "f666482f-e90f-4e22-9d3d-69c3ee5442c2", "Slovenia" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: "2e2bfac9-4671-4b3f-8684-100b21e60b30");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: "37c00aa0-b7de-4df2-9277-da14ab91d122");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: "3e6773cb-dd81-4f92-91a6-05816ba80c07");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: "526ac75f-18c7-47c0-bc3c-733074a607e2");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: "6f511291-50cf-4bb1-bd29-9c1dc627bf76");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: "7734eba6-bbd6-413b-aa0d-4e990edb57a3");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: "d3312ea7-f12a-4e69-97a4-8a05c951626c");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: "f332fd70-5e14-4973-b46f-c769912ddc03");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: "f666482f-e90f-4e22-9d3d-69c3ee5442c2");
        }
    }
}
