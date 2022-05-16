using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    public partial class ScoreStatSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
