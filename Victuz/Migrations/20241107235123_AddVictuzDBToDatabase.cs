using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Victuz.Migrations
{
    /// <inheritdoc />
    public partial class AddVictuzDBToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScreenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Validated = table.Column<bool>(type: "bit", nullable: false),
                    Board = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Propositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusDisplay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Propositions_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "Date", "Description", "Location", "Name" },
                values: new object[] { 1, "Workshop", new DateTime(2024, 11, 8, 0, 51, 22, 747, DateTimeKind.Local).AddTicks(9651), "Test Description", "Test room", "Test Name" });

            migrationBuilder.InsertData(
                table: "Agendas",
                columns: new[] { "Id", "Date", "Name" },
                values: new object[] { 1, new DateTime(2024, 11, 8, 0, 51, 22, 747, DateTimeKind.Local).AddTicks(9793), "Test" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Board", "Email", "LastName", "Name", "Password", "ScreenName", "Validated" },
                values: new object[] { 1, true, "administrator@gmail.com", "Istrator", "Admin", "admin", "Tester", true });

            migrationBuilder.InsertData(
                table: "Propositions",
                columns: new[] { "Id", "Date", "Description", "MemberName", "Name", "StatusDisplay", "StatusId" },
                values: new object[] { 1, new DateTime(2024, 11, 8, 0, 51, 22, 747, DateTimeKind.Local).AddTicks(9824), "Test", "Test", "Test", "In behandeling", null });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Test", "In Progress" });

            migrationBuilder.CreateIndex(
                name: "IX_Propositions_StatusId",
                table: "Propositions",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Propositions");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
