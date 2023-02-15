using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinterIsComing.Infrastructure.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resorts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Elevation = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumberOfSlopes = table.Column<int>(type: "int", nullable: false),
                    SkiAreaSizes = table.Column<double>(type: "float", nullable: false),
                    CountryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resorts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resorts_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserResort",
                columns: table => new
                {
                    FavouriteResortsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserResort", x => new { x.FavouriteResortsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AppUserResort_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserResort_Resorts_FavouriteResortsId",
                        column: x => x.FavouriteResortsId,
                        principalTable: "Resorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ResortId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Resorts_ResortId",
                        column: x => x.ResortId,
                        principalTable: "Resorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PassType = table.Column<int>(type: "int", nullable: false),
                    ResortId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_Resorts_ResortId",
                        column: x => x.ResortId,
                        principalTable: "Resorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Resorts",
                columns: new[] { "Id", "CountryId", "Description", "Elevation", "ImageUrl", "Name", "NumberOfSlopes", "SkiAreaSizes" },
                values: new object[,]
                {
                    { "239fb5bc-f32a-44ff-ad30-992feda18a41", "3e6773cb-dd81-4f92-91a6-05816ba80c07", "Malyovitsa is located in the Rila mountain. There are no lifts just rope tows. It's good for freeride.", "2000", "https://4vlast-bg.com/wp-content/uploads/2021/01/89911107_166885198185957_7272630966554722304_o.jpg", "Malyovitsa", 2, 4.0 },
                    { "2d5a0fa8-fcb9-46d7-8f19-01f5fb543116", "3e6773cb-dd81-4f92-91a6-05816ba80c07", "Rila Lakes is located in the Rila mountain. There is one slow lift and one rope tows. It's good for freeride and backcountry.", "2300", "https://www.360mag.bg/wp-content/uploads/2016/12/bg-kurorti-rilski-ezera.jpg", "Rila Lakes", 2, 3.0 },
                    { "4b604930-85d7-44d5-9d4b-4844d1745742", "3e6773cb-dd81-4f92-91a6-05816ba80c07", "Pamporovo is located in the Rhodope mountain. It offers warm hospitality and is very suitable for beginners.", "1920", "https://www.igluski.com/images/_i60381238.jpg", "Pamporovo", 20, 36.799999999999997 },
                    { "4b94a373-e809-4f52-90c2-af49ed73cb30", "3e6773cb-dd81-4f92-91a6-05816ba80c07", "Kartala is located close to Blagoevgrad in the Rila mountain. Not a lot of slopes but good for freeride.", "2350", "https://bg.nexustrace.com/wp-content/uploads/2020/11/kartala-2.jpg", "Kartala", 2, 5.0 },
                    { "79e82d3d-7482-4ffe-8c1c-55a0e47798ec", "3e6773cb-dd81-4f92-91a6-05816ba80c07", "Bezbog is located in the Pirin mountain next to Bansko. There is only one slope but is a favourite site for freeride and backcountry.", "2240", "https://bulgariaview.com/view/albums/17/46.jpg", "Bezbog", 1, 5.0 },
                    { "7f412e7c-3999-476e-8f5f-a7a14440ea4b", "3e6773cb-dd81-4f92-91a6-05816ba80c07", "Bansko is the biggest ski resort in Bulgaria located in the Pirin mountain. It hosts FIS World Cup alpine ski races.", "2600", "https://www.skibansko.bg/wp-content/uploads/2016/06/bansko-ski-runs.jpg", "Bansko", 20, 75.0 },
                    { "bd83c318-a14f-4113-9408-0d71d19beb98", "3e6773cb-dd81-4f92-91a6-05816ba80c07", "Vitosha is located just 20km away from Sofia city center.Unfortunately most of the lifts are abandoned and few are working.", "2200", "https://www.skiresort.info/fileadmin/_processed_/29/94/4a/a0/ba07658242.jpg", "Vitosha", 12, 36.799999999999997 },
                    { "be4598ef-38d2-4acb-bf23-8b859d4a2b21", "3e6773cb-dd81-4f92-91a6-05816ba80c07", "Borovets is the second biggest ski resort in Bulgaria located in the Rila mountain.It offers night skiing.", "2500", "https://www.skiborovets.bg/wp-content/uploads/2016/08/borovets-night-skiing.jpg", "Borovets", 27, 58.0 }
                });

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
                    { "515cd33d-742a-40b3-a664-b5a1136c988a", 1, "2d5a0fa8-fcb9-46d7-8f19-01f5fb543116", 40m },
                    { "59f29a21-69eb-47b2-ab5f-760050e3330d", 0, "7f412e7c-3999-476e-8f5f-a7a14440ea4b", 70m },
                    { "5e9370d6-fc61-4c39-b33b-1d83e85e40a1", 1, "4b604930-85d7-44d5-9d4b-4844d1745742", 85m },
                    { "626ce16f-e1e6-4e1b-bb43-08253a60717b", 1, "239fb5bc-f32a-44ff-ad30-992feda18a41", 25m },
                    { "827d687e-6ca8-417a-b16c-42b5a93f25c8", 1, "79e82d3d-7482-4ffe-8c1c-55a0e47798ec", 47m },
                    { "93b23e49-c762-47df-813f-046012736838", 0, "4b94a373-e809-4f52-90c2-af49ed73cb30", 45m },
                    { "9c587e25-5941-496c-aa6d-c2bc688a8877", 2, "7f412e7c-3999-476e-8f5f-a7a14440ea4b", 1700m },
                    { "b8816896-8c30-49b1-9173-a8c0cf70dd39", 0, "be4598ef-38d2-4acb-bf23-8b859d4a2b21", 70m },
                    { "baf8f5d8-583d-4815-af0b-a0027b2e46f5", 2, "bd83c318-a14f-4113-9408-0d71d19beb98", 650m },
                    { "bbda776e-f33a-43a0-9b58-9657785b39f2", 0, "2d5a0fa8-fcb9-46d7-8f19-01f5fb543116", 30m },
                    { "c799e62e-50f3-441f-8c4a-26fae8db5339", 0, "4b604930-85d7-44d5-9d4b-4844d1745742", 63m },
                    { "d2477f38-8927-4c5e-a875-1e617d167871", 1, "7f412e7c-3999-476e-8f5f-a7a14440ea4b", 90m },
                    { "dd8ca596-0912-4a6e-8479-8d966962a23e", 1, "4b94a373-e809-4f52-90c2-af49ed73cb30", 60m },
                    { "ebc0e4f5-8eaf-45a1-8797-85220f027593", 2, "4b604930-85d7-44d5-9d4b-4844d1745742", 1530m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserResort_UsersId",
                table: "AppUserResort",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_AppUserId",
                table: "Likes",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ResortId",
                table: "Likes",
                column: "ResortId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ResortId",
                table: "Prices",
                column: "ResortId");

            migrationBuilder.CreateIndex(
                name: "IX_Resorts_CountryId",
                table: "Resorts",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserResort");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Resorts");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
