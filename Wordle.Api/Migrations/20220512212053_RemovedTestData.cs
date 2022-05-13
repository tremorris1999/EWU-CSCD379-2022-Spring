using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    public partial class RemovedTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "Name" },
                values: new object[] { 1, "Inigo Montoya" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "Name" },
                values: new object[] { 2, "Prince Humperdink" });
        }
    }
}
