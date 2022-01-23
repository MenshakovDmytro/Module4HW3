using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Module4HW3.Migrations
{
    public partial class AddClientTableAndDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(1998, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "ShamikaFJohnson@armyspy.com", "Shamika", "F", "Johnson", "804-837-7518" },
                    { 2, null, "JuanRHernandez@jourrapide.com", "Juan", "M", "Hernandez", "916-663-8311" },
                    { 3, new DateTimeOffset(new DateTime(1975, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "RichardMWilliamson@jourrapide.com", "Richard", "M", "Williamson", "808-955-6175" },
                    { 4, null, "MistyMFowler@armyspy.com", "Misty", "F", "Fowler", "252-467-3244" },
                    { 5, null, "SeanTJohnson@rhyta.com", "Sean", "M", "Johnson", "540-605-5503" }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "Budget", "ClientId", "Name", "StartedDate" },
                values: new object[,]
                {
                    { 1, 5000m, 1, "ProjectOne", new DateTimeOffset(new DateTime(2015, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 2, 15000m, 2, "ProjectTwo", new DateTimeOffset(new DateTime(2013, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 3, 7500m, 3, "ProjectThree", new DateTimeOffset(new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 4, 6000m, 4, "ProjectFour", new DateTimeOffset(new DateTime(2019, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 5, 50000m, 5, "ProjectFive", new DateTimeOffset(new DateTime(2010, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Project_ClientId",
                table: "Project");

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Project");
        }
    }
}
