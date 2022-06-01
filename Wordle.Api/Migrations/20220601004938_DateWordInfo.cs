using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    public partial class DateWordInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AverageGuesses",
                table: "DateWords",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "AverageSeconds",
                table: "DateWords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Plays",
                table: "DateWords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageGuesses",
                table: "DateWords");

            migrationBuilder.DropColumn(
                name: "AverageSeconds",
                table: "DateWords");

            migrationBuilder.DropColumn(
                name: "Plays",
                table: "DateWords");
        }
    }
}
