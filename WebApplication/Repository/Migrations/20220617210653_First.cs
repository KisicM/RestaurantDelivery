using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Repository.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Approved = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Approved", "DateOfBirth", "Email", "Image", "Name", "Password", "Surname", "UserRole", "Username" },
                values: new object[,]
                {
                    { -1, "Novi Sad", true, new DateTime(2022, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe@gmail.com", "", "John", "ftn", "Doe", 2, "admin" },
                    { -2, "Novi Sad", false, new DateTime(2022, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe@gmail.com", "", "John", "ftn", "Doe", 1, "deliverer" },
                    { -3, "Novi Sad", true, new DateTime(2022, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe@gmail.com", "", "John", "ftn", "Doe", 0, "customer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
