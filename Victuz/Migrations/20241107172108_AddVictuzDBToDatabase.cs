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
                name: "Agenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgendaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_Agenda_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agenda",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Proposition",
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
                    table.PrimaryKey("PK_Proposition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposition_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Member",
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
                    Board = table.Column<bool>(type: "bit", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "Id", "AgendaId", "Category", "Date", "Description", "Location", "Name" },
                values: new object[] { 1, null, "Workshop", new DateTime(2024, 11, 7, 18, 21, 7, 866, DateTimeKind.Local).AddTicks(4720), "Test Description", "Test room", "Test Name" });

            migrationBuilder.InsertData(
                table: "Agenda",
                columns: new[] { "Id", "Date", "Name" },
                values: new object[] { 1, new DateTime(2024, 11, 7, 18, 21, 7, 866, DateTimeKind.Local).AddTicks(4886), "Test" });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Id", "ActivityId", "Board", "Email", "LastName", "Name", "Password", "ScreenName", "Validated" },
                values: new object[] { 1, null, true, "administrator@gmail.com", "Istrator", "Admin", "admin", "Tester", true });

            migrationBuilder.InsertData(
                table: "Proposition",
                columns: new[] { "Id", "Date", "Description", "MemberName", "Name", "StatusDisplay", "StatusId" },
                values: new object[] { 1, new DateTime(2024, 11, 7, 18, 21, 7, 866, DateTimeKind.Local).AddTicks(4919), "Test", "Test", "Test", "In behandeling", null });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Test", "In Progress" });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_AgendaId",
                table: "Activity",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_ActivityId",
                table: "Member",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposition_StatusId",
                table: "Proposition",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Proposition");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Agenda");
        }
    }
}
