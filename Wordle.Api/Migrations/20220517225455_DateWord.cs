using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    public partial class DateWord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DateWords",
                columns: table => new
                {
                    DateWordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateWords", x => x.DateWordId);
                    table.ForeignKey(
                        name: "FK_DateWords_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "WordId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.Sql("Delete from ScoreStats");
            migrationBuilder.InsertData(
                table: "ScoreStats",
                columns: new[] { "ScoreStatId", "AverageSeconds", "Score", "TotalGames" },
                values: new object[,]
                {
                    { 1, 0, 1, 0 },
                    { 2, 0, 2, 0 },
                    { 3, 0, 3, 0 },
                    { 4, 0, 4, 0 },
                    { 5, 0, 5, 0 },
                    { 6, 0, 6, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DateWords_WordId",
                table: "DateWords",
                column: "WordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DateWords");

            migrationBuilder.DeleteData(
                table: "ScoreStats",
                keyColumn: "ScoreStatId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ScoreStats",
                keyColumn: "ScoreStatId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ScoreStats",
                keyColumn: "ScoreStatId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ScoreStats",
                keyColumn: "ScoreStatId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ScoreStats",
                keyColumn: "ScoreStatId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ScoreStats",
                keyColumn: "ScoreStatId",
                keyValue: 6);
        }
    }
}
