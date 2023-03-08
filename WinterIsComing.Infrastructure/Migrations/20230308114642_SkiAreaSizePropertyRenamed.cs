using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinterIsComing.Infrastructure.Migrations
{
    public partial class SkiAreaSizePropertyRenamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SkiAreaSizes",
                table: "Resorts",
                newName: "SkiAreaSize");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SkiAreaSize",
                table: "Resorts",
                newName: "SkiAreaSizes");
        }
    }
}
