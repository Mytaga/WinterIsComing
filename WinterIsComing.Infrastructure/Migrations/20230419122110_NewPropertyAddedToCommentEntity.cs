using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinterIsComing.Infrastructure.Migrations
{
    public partial class NewPropertyAddedToCommentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserPhoto",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserPhoto",
                table: "Comments");
        }
    }
}
