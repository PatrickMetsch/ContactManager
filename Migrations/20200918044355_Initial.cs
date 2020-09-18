using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactManager.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ManagerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Organization = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    CategoryId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManagerId);
                    table.ForeignKey(
                        name: "FK_Managers_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { "F", "Friend" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { "P", "Professional" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { "M", "Family" });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "ManagerId", "CategoryId", "Created", "Email", "FirstName", "LastName", "Organization", "Phone" },
                values: new object[] { 5, "F", new DateTime(2008, 6, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "karen.butterhaven@helloworld.com", "Bruce", "Sourhouse", null, "440-488-2001" });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "ManagerId", "CategoryId", "Created", "Email", "FirstName", "LastName", "Organization", "Phone" },
                values: new object[] { 6, "P", new DateTime(2020, 9, 18, 0, 43, 54, 864, DateTimeKind.Local).AddTicks(920), "karen.butterhaven@helloworld.com", "Louis", "Vanderbloke", null, "216-731-1138" });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "ManagerId", "CategoryId", "Created", "Email", "FirstName", "LastName", "Organization", "Phone" },
                values: new object[] { 4, "M", new DateTime(2020, 9, 18, 0, 43, 54, 854, DateTimeKind.Local).AddTicks(7480), "karen.butterhaven@helloworld.com", "Karen", "Butterhaven", "Galapagos International", "481-516-2342" });

            migrationBuilder.CreateIndex(
                name: "IX_Managers_CategoryId",
                table: "Managers",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
