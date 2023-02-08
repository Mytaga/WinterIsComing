﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WinterIsComing.Infrastructure.Data;

#nullable disable

namespace WinterIsComing.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230208093319_IdentityChanges")]
    partial class IdentityChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AppUserResort", b =>
                {
                    b.Property<string>("FavouriteResortsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FavouriteResortsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("AppUserResort");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WinterIsComing.Infrastructure.Data.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("WinterIsComing.Infrastructure.Data.Models.Country", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = "3e6773cb-dd81-4f92-91a6-05816ba80c07",
                            Name = "Bulgaria"
                        },
                        new
                        {
                            Id = "6f511291-50cf-4bb1-bd29-9c1dc627bf76",
                            Name = "Austria"
                        },
                        new
                        {
                            Id = "2e2bfac9-4671-4b3f-8684-100b21e60b30",
                            Name = "Greece"
                        },
                        new
                        {
                            Id = "d3312ea7-f12a-4e69-97a4-8a05c951626c",
                            Name = "Serbia"
                        },
                        new
                        {
                            Id = "7734eba6-bbd6-413b-aa0d-4e990edb57a3",
                            Name = "Romania"
                        },
                        new
                        {
                            Id = "f332fd70-5e14-4973-b46f-c769912ddc03",
                            Name = "Italy"
                        },
                        new
                        {
                            Id = "526ac75f-18c7-47c0-bc3c-733074a607e2",
                            Name = "France"
                        },
                        new
                        {
                            Id = "f666482f-e90f-4e22-9d3d-69c3ee5442c2",
                            Name = "Slovenia"
                        },
                        new
                        {
                            Id = "37c00aa0-b7de-4df2-9277-da14ab91d122",
                            Name = "Andora"
                        });
                });

            modelBuilder.Entity("WinterIsComing.Infrastructure.Data.Models.Price", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PassType")
                        .HasColumnType("int");

                    b.Property<string>("ResortId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ResortId");

                    b.ToTable("Prices");

                    b.HasData(
                        new
                        {
                            Id = "d2477f38-8927-4c5e-a875-1e617d167871",
                            PassType = 1,
                            ResortId = "7f412e7c-3999-476e-8f5f-a7a14440ea4b",
                            Value = 90m
                        },
                        new
                        {
                            Id = "59f29a21-69eb-47b2-ab5f-760050e3330d",
                            PassType = 0,
                            ResortId = "7f412e7c-3999-476e-8f5f-a7a14440ea4b",
                            Value = 70m
                        },
                        new
                        {
                            Id = "9c587e25-5941-496c-aa6d-c2bc688a8877",
                            PassType = 2,
                            ResortId = "7f412e7c-3999-476e-8f5f-a7a14440ea4b",
                            Value = 1700m
                        },
                        new
                        {
                            Id = "09c02bc4-5ba9-43ee-b79f-dc18842c8e0b",
                            PassType = 1,
                            ResortId = "be4598ef-38d2-4acb-bf23-8b859d4a2b21",
                            Value = 85m
                        },
                        new
                        {
                            Id = "b8816896-8c30-49b1-9173-a8c0cf70dd39",
                            PassType = 0,
                            ResortId = "be4598ef-38d2-4acb-bf23-8b859d4a2b21",
                            Value = 70m
                        },
                        new
                        {
                            Id = "08050311-981e-4e03-8837-95c550c92a2e",
                            PassType = 2,
                            ResortId = "be4598ef-38d2-4acb-bf23-8b859d4a2b21",
                            Value = 1500m
                        },
                        new
                        {
                            Id = "5e9370d6-fc61-4c39-b33b-1d83e85e40a1",
                            PassType = 1,
                            ResortId = "4b604930-85d7-44d5-9d4b-4844d1745742",
                            Value = 85m
                        },
                        new
                        {
                            Id = "c799e62e-50f3-441f-8c4a-26fae8db5339",
                            PassType = 0,
                            ResortId = "4b604930-85d7-44d5-9d4b-4844d1745742",
                            Value = 63m
                        },
                        new
                        {
                            Id = "ebc0e4f5-8eaf-45a1-8797-85220f027593",
                            PassType = 2,
                            ResortId = "4b604930-85d7-44d5-9d4b-4844d1745742",
                            Value = 1530m
                        },
                        new
                        {
                            Id = "374705e6-309f-4ec0-9936-4c1cc15c527a",
                            PassType = 1,
                            ResortId = "bd83c318-a14f-4113-9408-0d71d19beb98",
                            Value = 50m
                        },
                        new
                        {
                            Id = "3d25295a-76b4-4a6e-ac2b-ccc75f50bbfd",
                            PassType = 0,
                            ResortId = "bd83c318-a14f-4113-9408-0d71d19beb98",
                            Value = 40m
                        },
                        new
                        {
                            Id = "baf8f5d8-583d-4815-af0b-a0027b2e46f5",
                            PassType = 2,
                            ResortId = "bd83c318-a14f-4113-9408-0d71d19beb98",
                            Value = 650m
                        },
                        new
                        {
                            Id = "dd8ca596-0912-4a6e-8479-8d966962a23e",
                            PassType = 1,
                            ResortId = "4b94a373-e809-4f52-90c2-af49ed73cb30",
                            Value = 60m
                        },
                        new
                        {
                            Id = "93b23e49-c762-47df-813f-046012736838",
                            PassType = 0,
                            ResortId = "4b94a373-e809-4f52-90c2-af49ed73cb30",
                            Value = 45m
                        },
                        new
                        {
                            Id = "827d687e-6ca8-417a-b16c-42b5a93f25c8",
                            PassType = 1,
                            ResortId = "79e82d3d-7482-4ffe-8c1c-55a0e47798ec",
                            Value = 47m
                        },
                        new
                        {
                            Id = "626ce16f-e1e6-4e1b-bb43-08253a60717b",
                            PassType = 1,
                            ResortId = "239fb5bc-f32a-44ff-ad30-992feda18a41",
                            Value = 25m
                        },
                        new
                        {
                            Id = "29f08d0a-bf1e-44ca-93af-ce05b2832275",
                            PassType = 0,
                            ResortId = "239fb5bc-f32a-44ff-ad30-992feda18a41",
                            Value = 18m
                        },
                        new
                        {
                            Id = "515cd33d-742a-40b3-a664-b5a1136c988a",
                            PassType = 1,
                            ResortId = "2d5a0fa8-fcb9-46d7-8f19-01f5fb543116",
                            Value = 40m
                        },
                        new
                        {
                            Id = "bbda776e-f33a-43a0-9b58-9657785b39f2",
                            PassType = 0,
                            ResortId = "2d5a0fa8-fcb9-46d7-8f19-01f5fb543116",
                            Value = 30m
                        });
                });

            modelBuilder.Entity("WinterIsComing.Infrastructure.Data.Models.Resort", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CountryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Elevation")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NumberOfSlopes")
                        .HasColumnType("int");

                    b.Property<double>("SkiAreaSizes")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Resorts");

                    b.HasData(
                        new
                        {
                            Id = "7f412e7c-3999-476e-8f5f-a7a14440ea4b",
                            CountryId = "3e6773cb-dd81-4f92-91a6-05816ba80c07",
                            Description = "Bansko is the biggest ski resort in Bulgaria located in the Pirin mountain. It hosts FIS World Cup alpine ski races.",
                            Elevation = "2600",
                            ImageUrl = "https://www.skibansko.bg/wp-content/uploads/2016/06/bansko-ski-runs.jpg",
                            Likes = 0,
                            Name = "Bansko",
                            NumberOfSlopes = 20,
                            SkiAreaSizes = 75.0
                        },
                        new
                        {
                            Id = "be4598ef-38d2-4acb-bf23-8b859d4a2b21",
                            CountryId = "3e6773cb-dd81-4f92-91a6-05816ba80c07",
                            Description = "Borovets is the second biggest ski resort in Bulgaria located in the Rila mountain.It offers night skiing.",
                            Elevation = "2500",
                            ImageUrl = "https://www.skiborovets.bg/wp-content/uploads/2016/08/borovets-night-skiing.jpg",
                            Likes = 0,
                            Name = "Borovets",
                            NumberOfSlopes = 27,
                            SkiAreaSizes = 58.0
                        },
                        new
                        {
                            Id = "4b604930-85d7-44d5-9d4b-4844d1745742",
                            CountryId = "3e6773cb-dd81-4f92-91a6-05816ba80c07",
                            Description = "Pamporovo is located in the Rhodope mountain. It offers warm hospitality and is very suitable for beginners.",
                            Elevation = "1920",
                            ImageUrl = "https://www.igluski.com/images/_i60381238.jpg",
                            Likes = 0,
                            Name = "Pamporovo",
                            NumberOfSlopes = 20,
                            SkiAreaSizes = 36.799999999999997
                        },
                        new
                        {
                            Id = "bd83c318-a14f-4113-9408-0d71d19beb98",
                            CountryId = "3e6773cb-dd81-4f92-91a6-05816ba80c07",
                            Description = "Vitosha is located just 20km away from Sofia city center.Unfortunately most of the lifts are abandoned and few are working.",
                            Elevation = "2200",
                            ImageUrl = "https://www.skiresort.info/fileadmin/_processed_/29/94/4a/a0/ba07658242.jpg",
                            Likes = 0,
                            Name = "Vitosha",
                            NumberOfSlopes = 12,
                            SkiAreaSizes = 36.799999999999997
                        },
                        new
                        {
                            Id = "4b94a373-e809-4f52-90c2-af49ed73cb30",
                            CountryId = "3e6773cb-dd81-4f92-91a6-05816ba80c07",
                            Description = "Kartala is located close to Blagoevgrad in the Rila mountain. Not a lot of slopes but good for freeride.",
                            Elevation = "2350",
                            ImageUrl = "https://bg.nexustrace.com/wp-content/uploads/2020/11/kartala-2.jpg",
                            Likes = 0,
                            Name = "Kartala",
                            NumberOfSlopes = 2,
                            SkiAreaSizes = 5.0
                        },
                        new
                        {
                            Id = "79e82d3d-7482-4ffe-8c1c-55a0e47798ec",
                            CountryId = "3e6773cb-dd81-4f92-91a6-05816ba80c07",
                            Description = "Bezbog is located in the Pirin mountain next to Bansko. There is only one slope but is a favourite site for freeride and backcountry.",
                            Elevation = "2240",
                            ImageUrl = "https://bulgariaview.com/view/albums/17/46.jpg",
                            Likes = 0,
                            Name = "Bezbog",
                            NumberOfSlopes = 1,
                            SkiAreaSizes = 5.0
                        },
                        new
                        {
                            Id = "239fb5bc-f32a-44ff-ad30-992feda18a41",
                            CountryId = "3e6773cb-dd81-4f92-91a6-05816ba80c07",
                            Description = "Malyovitsa is located in the Rila mountain. There are no lifts just rope tows. It's good for freeride.",
                            Elevation = "2000",
                            ImageUrl = "https://4vlast-bg.com/wp-content/uploads/2021/01/89911107_166885198185957_7272630966554722304_o.jpg",
                            Likes = 0,
                            Name = "Malyovitsa",
                            NumberOfSlopes = 2,
                            SkiAreaSizes = 4.0
                        },
                        new
                        {
                            Id = "2d5a0fa8-fcb9-46d7-8f19-01f5fb543116",
                            CountryId = "3e6773cb-dd81-4f92-91a6-05816ba80c07",
                            Description = "Rila Lakes is located in the Rila mountain. There is one slow lift and one rope tows. It's good for freeride and backcountry.",
                            Elevation = "2300",
                            ImageUrl = "https://www.360mag.bg/wp-content/uploads/2016/12/bg-kurorti-rilski-ezera.jpg",
                            Likes = 0,
                            Name = "Rila Lakes",
                            NumberOfSlopes = 2,
                            SkiAreaSizes = 3.0
                        });
                });

            modelBuilder.Entity("WinterIsComing.Infrastructure.Data.Models.UserResort", b =>
                {
                    b.Property<string>("ResortId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ResortId", "AppUserId");

                    b.HasIndex("AppUserId");

                    b.ToTable("UserResorts");
                });

            modelBuilder.Entity("AppUserResort", b =>
                {
                    b.HasOne("WinterIsComing.Infrastructure.Data.Models.Resort", null)
                        .WithMany()
                        .HasForeignKey("FavouriteResortsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WinterIsComing.Infrastructure.Data.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WinterIsComing.Infrastructure.Data.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WinterIsComing.Infrastructure.Data.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WinterIsComing.Infrastructure.Data.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WinterIsComing.Infrastructure.Data.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WinterIsComing.Infrastructure.Data.Models.Price", b =>
                {
                    b.HasOne("WinterIsComing.Infrastructure.Data.Models.Resort", "Resort")
                        .WithMany("LiftPassPrices")
                        .HasForeignKey("ResortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resort");
                });

            modelBuilder.Entity("WinterIsComing.Infrastructure.Data.Models.Resort", b =>
                {
                    b.HasOne("WinterIsComing.Infrastructure.Data.Models.Country", "Country")
                        .WithMany("Resorts")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("WinterIsComing.Infrastructure.Data.Models.UserResort", b =>
                {
                    b.HasOne("WinterIsComing.Infrastructure.Data.Models.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WinterIsComing.Infrastructure.Data.Models.Resort", "Resort")
                        .WithMany()
                        .HasForeignKey("ResortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resort");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WinterIsComing.Infrastructure.Data.Models.Country", b =>
                {
                    b.Navigation("Resorts");
                });

            modelBuilder.Entity("WinterIsComing.Infrastructure.Data.Models.Resort", b =>
                {
                    b.Navigation("LiftPassPrices");
                });
#pragma warning restore 612, 618
        }
    }
}
