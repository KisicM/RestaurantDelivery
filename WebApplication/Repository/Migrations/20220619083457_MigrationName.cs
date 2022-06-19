using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Repository.Migrations
{
    public partial class MigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Ingredients = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    DelivererId = table.Column<int>(type: "integer", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    UserRole = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Approved = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "Ingredients", "Name", "Price" },
                values: new object[,]
                {
                    { -1, "smth", "Pizza", 250.0 },
                    { -2, "smth", "Vine", 250.0 }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "Address", "Comment", "CustomerId", "DelivererId", "EndTime", "Price", "StartTime" },
                values: new object[,]
                {
                    { -1, "Novi Sad", "Ring", -3, 0, new DateTime(2022, 6, 25, 15, 5, 0, 0, DateTimeKind.Unspecified), 500.0, new DateTime(2022, 6, 25, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -2, "Novi Sad", "Ring", -3, -2, new DateTime(2022, 6, 25, 15, 5, 0, 0, DateTimeKind.Unspecified), 250.0, new DateTime(2022, 6, 25, 15, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Approved", "DateOfBirth", "Email", "Image", "Name", "Password", "Status", "Surname", "UserRole", "Username" },
                values: new object[,]
                {
                    { -1, "Novi Sad", true, new DateTime(2022, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe@gmail.com", "", "John", "ftn", 1, "Doe", 2, "admin" },
                    { -2, "Novi Sad", false, new DateTime(2022, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe@gmail.com", "", "John", "ftn", 0, "Doe", 1, "deliverer" },
                    { -3, "Novi Sad", true, new DateTime(2022, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe@gmail.com", "", "John", "ftn", 1, "Doe", 0, "customer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
