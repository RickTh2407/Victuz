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
                name: "Newses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newses", x => x.Id);
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
                    Board = table.Column<bool>(type: "bit", nullable: false),
                    NewsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Newses_NewsId",
                        column: x => x.NewsId,
                        principalTable: "Newses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
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
                    StatusesId = table.Column<int>(type: "int", nullable: true),
                    MembersId = table.Column<int>(type: "int", nullable: true),
                    StatusDisplay = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Propositions_Members_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Propositions_Statuses_StatusesId",
                        column: x => x.StatusesId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                });

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
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgendasId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Agendas_AgendasId",
                        column: x => x.AgendasId,
                        principalTable: "Agendas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Activities_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActivityMember",
                columns: table => new
                {
                    ActivitiesId = table.Column<int>(type: "int", nullable: false),
                    MembersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityMember", x => new { x.ActivitiesId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_ActivityMember_Activities_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityMember_Members_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Activities",
<<<<<<<< HEAD:Victuz/Migrations/20241108125436_AddVictuzDBToDatabase.cs
                columns: new[] { "Id", "AgendasId", "Category", "CategoryId", "Date", "Description", "Location", "Name" },
                values: new object[] { 1, null, "Workshop", null, new DateTime(2024, 11, 8, 13, 54, 35, 725, DateTimeKind.Local).AddTicks(3769), "Test Description", "Test room", "Test Name" });
========
                columns: new[] { "Id", "AgendasId", "Category", "Date", "Description", "Location", "Name" },
                values: new object[] { 1, null, "Workshop", new DateTime(2024, 11, 8, 13, 34, 25, 725, DateTimeKind.Local).AddTicks(9651), "Test Description", "Test room", "Test Name" });
>>>>>>>> ec50f7f5bf5d2fb66b7e2979db7e4792d7a38652:Victuz/Migrations/20241108123427_AddVictuzDBToDatabase.cs

            migrationBuilder.InsertData(
                table: "Agendas",
                columns: new[] { "Id", "Date", "Name" },
<<<<<<<< HEAD:Victuz/Migrations/20241108125436_AddVictuzDBToDatabase.cs
                values: new object[] { 1, new DateTime(2024, 11, 8, 13, 54, 35, 725, DateTimeKind.Local).AddTicks(3919), "Test" });
========
                values: new object[] { 1, new DateTime(2024, 11, 8, 13, 34, 25, 725, DateTimeKind.Local).AddTicks(9907), "Test" });
>>>>>>>> ec50f7f5bf5d2fb66b7e2979db7e4792d7a38652:Victuz/Migrations/20241108123427_AddVictuzDBToDatabase.cs

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Board", "Email", "LastName", "Name", "NewsId", "Password", "ScreenName", "Validated" },
                values: new object[] { 1, true, "administrator@gmail.com", "Istrator", "Admin", null, "admin", "Tester", true });

            migrationBuilder.InsertData(
                table: "Newses",
                columns: new[] { "Id", "CreatedDate", "Description", "Title" },
                values: new object[] { 1, new DateTime(2024, 11, 8, 13, 54, 35, 725, DateTimeKind.Local).AddTicks(3995), "Test description", "Test Title" });

            migrationBuilder.InsertData(
                table: "Propositions",
                columns: new[] { "Id", "Date", "Description", "MemberName", "MembersId", "Name", "StatusDisplay", "StatusesId" },
<<<<<<<< HEAD:Victuz/Migrations/20241108125436_AddVictuzDBToDatabase.cs
                values: new object[] { 1, new DateTime(2024, 11, 8, 13, 54, 35, 725, DateTimeKind.Local).AddTicks(3963), "Test", "Test", null, "Test", "In behandeling", null });
========
                values: new object[] { 1, new DateTime(2024, 11, 8, 13, 34, 25, 726, DateTimeKind.Local).AddTicks(62), "Test", "Test", null, "Test", "In behandeling", null });
>>>>>>>> ec50f7f5bf5d2fb66b7e2979db7e4792d7a38652:Victuz/Migrations/20241108123427_AddVictuzDBToDatabase.cs

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Test", "In Progress" });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_AgendasId",
                table: "Activities",
                column: "AgendasId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CategoryId",
                table: "Activities",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityMember_MembersId",
                table: "ActivityMember",
                column: "MembersId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_MemberId",
                table: "Category",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_NewsId",
                table: "Members",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Propositions_MembersId",
                table: "Propositions",
                column: "MembersId");

            migrationBuilder.CreateIndex(
                name: "IX_Propositions_StatusesId",
                table: "Propositions",
                column: "StatusesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityMember");

            migrationBuilder.DropTable(
                name: "Propositions");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Newses");
        }
    }
}
